// ==========================================================================
// TemplateBuilder.js
// Drag-and-drop DSR template builder.
// Talks to TemplateBuilder.aspx/*  WebMethods via jQuery $.ajax (JSON).
// ==========================================================================
(function ($) {
$(function () {

    var headerSeq = 0;
    var fieldSeq = 0;
    var currentTemplateId = 0;     // 0 = creating a new template, >0 = editing an existing one

    // ---- track which palette fields are already placed on the canvas, so the
    // same schema/custom/formula field can't be dropped into a second header ----
    var usedFieldKeys = {};

    function fieldKeyFor(sourceType, sourceTable, sourceColumn) {
        return String(sourceType || '').toLowerCase() + '|' + String(sourceTable || '') + '|' + String(sourceColumn || '');
    }

    function setChipUsedState($chip, used) {
        $chip.toggleClass('used', !!used);
        if ($chip.data('draggable-ready')) $chip.draggable(used ? 'disable' : 'enable');
    }

    // called right after a palette chip is created, in case it represents a
    // field that's already on the canvas (e.g. re-browsing a table's columns,
    // or loading an existing template for edit before its schema table is picked)
    function applyChipUsedState($chip) {
        var key = fieldKeyFor($chip.data('source-type'), $chip.data('source-table'), $chip.data('source-column'));
        if (usedFieldKeys[key]) setChipUsedState($chip, true);
    }

    function findChipByKey(key) {
        var found = null;
        $('#schemaFieldList .field-chip, #customFieldList .field-chip').each(function () {
            var $c = $(this);
            if (fieldKeyFor($c.data('source-type'), $c.data('source-table'), $c.data('source-column')) === key) {
                found = $c;
                return false;
            }
        });
        return found;
    }

    // called whenever a canvas field is removed (or its header is removed) so
    // the originating palette chip becomes available to drag again
    function releaseFieldKey(key) {
        if (!key) return;
        delete usedFieldKeys[key];
        var $chip = findChipByKey(key);
        if ($chip) setChipUsedState($chip, false);
    }

    function resetUsedFieldTracking() {
        usedFieldKeys = {};
        $('#schemaFieldList .field-chip, #customFieldList .field-chip').each(function () {
            setChipUsedState($(this), false);
        });
    }

    // ---- per-header / total field counts ----
    function updateHeaderFieldCount($header) {
        var count = $header.find('.field-row').length;
        $header.find('.header-field-count').text(count + (count === 1 ? ' field' : ' fields'));
    }

    function updateTotalFieldCount() {
        $('#lblTotalFieldCount').text($('#headerContainer .field-row').length);
    }

    function updateFieldCounts($header) {
        if ($header && $header.length) updateHeaderFieldCount($header);
        updateTotalFieldCount();
    }

    function updateAllFieldCounts() {
        $('#headerContainer .header-block').each(function () { updateHeaderFieldCount($(this)); });
        updateTotalFieldCount();
    }

    // ---- open a popup window centered on the user's screen ----
    function openCenteredPopup(url, name, w, h) {
        var left = Math.max(0, (screen.width - w) / 2);
        var top = Math.max(0, (screen.height - h) / 2);
        window.open(url, name,
            'width=' + w + ',height=' + h + ',left=' + left + ',top=' + top + ',resizable=yes,scrollbars=yes');
    }

    // ---- render helpers (tiny manual templating, no extra library needed) ----
    function renderHeaderBlock(id, name, serverId) {
        var $tpl = $($('#tmplHeader').html()
            .replace('{id}', id)
            .replace('{name}', name || '')
            .replace('{serverId}', serverId || ''));
        return $tpl;
    }

    function renderFieldRow(opts) {
        // opts: key, serverId, label, sourceType, sourceTable, sourceColumn, type, options, required
        var html = $('#tmplFieldRow').html()
            .replace('{key}', opts.key)
            .replace('{serverId}', opts.serverId || '')
            .replace('{sourceType}', opts.sourceType || 'Manual')
            .replace('{sourceTable}', opts.sourceTable || '')
            .replace('{sourceColumn}', opts.sourceColumn || '')
            .replace('{label}', opts.label || '');
        var $row = $(html);
        $row.find('.type-select').val(opts.type || 'Textbox');
        if ((opts.type || 'Textbox') === 'Dropdown') {
            $row.find('.dropdown-opts').show().val(opts.options || '');
        }
        if (opts.required) $row.find('.required-flag').prop('checked', true);
        if (opts.formulaOperation) {
            $row.addClass('formula')
                .attr('data-formula-op', opts.formulaOperation)
                .attr('data-formula-sources', opts.formulaSources || '');
            $row.find('.type-select').prop('disabled', true);
        }
        wireFieldRow($row);
        return $row;
    }

    function wireFieldRow($row) {
        $row.find('.type-select').on('change', function () {
            var isDropdown = $(this).val() === 'Dropdown';
            $row.find('.dropdown-opts').toggle(isDropdown);
        });
        $row.find('.remove-field').on('click', function () {
            if ($row.hasClass('locked')) return; // Header Access: read-only for this user
            var $header = $row.closest('.header-block');
            releaseFieldKey($row.data('field-key'));
            $row.remove();
            updateFieldCounts($header);
        });
    }

    // ---- Import/Export type drives which tables + party names are offered ----
    var currentType = $('#ddlType').val() || 'Import';

    $('#ddlType').on('change', function () {
        currentType = $(this).val();
        $('#lblPartyLabel').text((currentType === 'Export' ? 'Exporter' : 'Importer') + ' Name');
        $('#txtPartySearch').attr('placeholder', 'Search ' + currentType.toLowerCase() + 'er...').val('');
        $('#lstParties').empty();
        $('#ddlTable').val('');
        $('#schemaFieldList').empty();
        loadPartyNames();
        loadTables();
    });

    // ---- autosearch importer/exporter name + add to listbox ----
    var partyNames = [];

    function loadPartyNames() {
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/GetPartyNames',
            contentType: 'application/json',
            data: JSON.stringify({ impExp: currentType }),
            success: function (res) {
                partyNames = res.d || [];
                $('#txtPartySearch').autocomplete({ source: partyNames });
            }
        });
    }

    $('#btnAddParty').on('click', function () {
        var name = $('#txtPartySearch').val().trim();
        if (!name) { alert('Search and pick a name first.'); return; }

        var partyLabel = currentType === 'Export' ? 'exporter' : 'importer';
        var matchedParty = partyNames.filter(function (p) { return p.toLowerCase() === name.toLowerCase(); })[0];
        if (!matchedParty) {
            alert('"' + name + '" is not a valid ' + partyLabel + ' name. Please choose one from the search suggestions.');
            return;
        }
        name = matchedParty;

        var alreadyAdded = $('#lstParties option').filter(function () {
            return $(this).val() === name;
        }).length > 0;
        if (alreadyAdded) { $('#txtPartySearch').val(''); return; }

        $('#lstParties').append($('<option>').val(name).text(name));
        $('#txtPartySearch').val('');
    });

    $('#btnRemoveParty').on('click', function () {
        $('#lstParties option:selected').remove();
    });

    // ---- load table list for the schema-field source ----
    function loadTables() {
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/GetTables',
            contentType: 'application/json',
            data: JSON.stringify({ impExp: currentType }),
            success: function (res) {
                var $ddl = $('#ddlTable');
                $ddl.empty().append('<option value="">-- choose table --</option>');
                $.each(res.d, function (i, t) {
                    $ddl.append($('<option>').val(t).text(t));
                });
            }
        });
    }

    $('#ddlTable').on('change', function () {
        var table = $(this).val();
        $('#schemaFieldList').empty();
        if (!table) return;
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/GetColumns',
            contentType: 'application/json',
            data: JSON.stringify({ tableName: table, impExp: currentType }),
            success: function (res) {
                $.each(res.d, function (i, col) {
                    var $chip = $('<div class="field-chip">')
                        .attr('data-source-table', table)
                        .attr('data-source-column', col.COLUMN_NAME)
                        .attr('data-suggested-type', col.SuggestedFieldType)
                        .html(col.COLUMN_NAME + '<small>' + table + ' · ' + col.DATA_TYPE + '</small>');
                    makeDraggable($chip, 'schema');
                    $('#schemaFieldList').append($chip);
                    applyChipUsedState($chip);
                });
            }
        });
    });

    // ---- computed field: operation dropdown toggles the source-fields picker ----
    function refreshFormulaSourceOptions() {
        var $lst = $('#lstCustomFieldSources').empty();
        $('#headerContainer .field-row').each(function () {
            var $f = $(this);
            if ($f.hasClass('formula')) return; // formulas can't reference other formulas
            var key = $f.data('source-column');
            var label = $f.find('.label-edit').val() || key;
            if (key) $lst.append($('<option>').val(key).text(label));
        });
    }

    $('#ddlCustomFieldOperation').on('change', function () {
        var op = $(this).val();
        if (op) {
            refreshFormulaSourceOptions();
            $('#lstCustomFieldSources').show();
            $('#ddlCustomFieldType').hide();
        } else {
            $('#lstCustomFieldSources').hide().empty();
            $('#ddlCustomFieldType').show();
        }
    });

    // ---- custom (manually typed) field palette ----
    $('#btnAddCustomField').on('click', function () {
        var name = $('#txtCustomFieldName').val().trim();
        var label = $('#txtCustomFieldLabel').val().trim() || name;
        var op = $('#ddlCustomFieldOperation').val();
        if (!name) { alert('Enter a field name first.'); return; }

        if (!op) {
            // ---- plain custom field (unchanged behavior) ----
            var type = $('#ddlCustomFieldType').val();
            var $chip = $('<div class="field-chip">')
                .attr('data-source-table', '')
                .attr('data-source-column', name)
                .attr('data-suggested-type', type)
                .attr('data-custom-label', label)
                .html(label + '<small>custom · ' + type + '</small>');
            makeDraggable($chip, 'manual');
            $('#customFieldList').append($chip);
            applyChipUsedState($chip);

            $('#txtCustomFieldName').val('');
            $('#txtCustomFieldLabel').val('');
            return;
        }

        // ---- computed field: total/sum, concatenate, or a greater/less-than flag ----
        var sourceKeys = $('#lstCustomFieldSources').val() || [];
        var isComparison = (op === 'GreaterThan' || op === 'LessThan');

        if (sourceKeys.length < 2) {
            alert('Select at least 2 fields to combine.');
            return;
        }
        if (isComparison && sourceKeys.length !== 2) {
            alert('Greater Than / Less Than compares exactly 2 fields - select only 2.');
            return;
        }

        var opLabels = { Sum: 'Total', Concat: 'Concat', GreaterThan: 'Greater Than', LessThan: 'Less Than' };
        var $chip = $('<div class="field-chip formula">')
            .attr('data-source-table', '')
            .attr('data-source-column', name)
            .attr('data-custom-label', label)
            .attr('data-formula-op', op)
            .attr('data-formula-sources', sourceKeys.join(','))
            .html(label + '<small>computed · ' + opLabels[op] + '</small>');
        makeDraggable($chip, 'formula');
        $('#customFieldList').append($chip);
        applyChipUsedState($chip);

        $('#txtCustomFieldName').val('');
        $('#txtCustomFieldLabel').val('');
        $('#ddlCustomFieldOperation').val('').trigger('change');
    });

    // ---- draggable palette chips ----
    function makeDraggable($chip, sourceType) {
        $chip.attr('data-source-type', sourceType);
        $chip.draggable({
            helper: 'clone',
            revert: 'invalid',
            appendTo: 'body',
            zIndex: 999
        });
        $chip.data('draggable-ready', true);
    }

    // ---- drop zones inside each header ----
    function wireDropzone($zone) {
        $zone.droppable({
            // Header Access: a locked header (see applyHeaderAccessLock) can't
            // accept a newly-dragged field at all - returning false here means
            // jQuery UI never fires `drop` for it and won't show the accepting
            // drag-over highlight either.
            accept: function () {
                return !$zone.closest('.header-block').hasClass('access-locked');
            },
            hoverClass: 'drag-over',
            drop: function (event, ui) {
                var $src = ui.draggable;
                var sourceType = $src.data('source-type');
                var sourceTable = $src.data('source-table') || '';
                var sourceColumn = $src.data('source-column');
                var key = fieldKeyFor(sourceType, sourceTable, sourceColumn);

                // already placed in this (or another) header - the chip should
                // already be frozen/disabled, this is just a safety net
                if (usedFieldKeys[key]) return;

                var $row;
                if (sourceType === 'formula') {
                    fieldSeq++;
                    $row = renderFieldRow({
                        key: 'f' + fieldSeq,
                        label: $src.data('custom-label'),
                        sourceType: 'Formula',
                        sourceTable: '',
                        sourceColumn: sourceColumn,
                        type: 'Textbox',
                        options: '',
                        formulaOperation: $src.data('formula-op'),
                        formulaSources: $src.data('formula-sources')
                    });
                } else {
                    var suggestedType = $src.data('suggested-type') || 'Textbox';
                    var label = sourceType === 'manual'
                        ? $src.data('custom-label')
                        : sourceColumn;

                    fieldSeq++;
                    $row = renderFieldRow({
                        key: 'f' + fieldSeq,
                        label: label,
                        sourceType: sourceType === 'manual' ? 'Manual' : 'Schema',
                        sourceTable: sourceTable,
                        sourceColumn: sourceColumn,
                        type: suggestedType,
                        options: ''
                    });
                }

                $row.attr('data-field-key', key);
                $zone.append($row);

                usedFieldKeys[key] = true;
                setChipUsedState($src, true);
                updateFieldCounts($zone.closest('.header-block'));
            }
        });

        // allow re-ordering fields within / across headers - connectWith is a
        // selector string (jQuery UI re-resolves it live at drag-start, not
        // once at init), so excluding locked headers (see
        // applyHeaderAccessLock) here keeps a field from being dragged into
        // one even if it was locked after this dropzone was first wired up
        $zone.sortable({
            connectWith: '.header-block:not(.access-locked) .dropzone',
            handle: '.handle',
            placeholder: 'field-row',
            items: '.field-row',
            // dragging an already-placed field across headers doesn't change
            // which fields are "used", just which header owns it - recount both ends
            receive: function () { updateFieldCounts($(this).closest('.header-block')); },
            remove: function () { updateFieldCounts($(this).closest('.header-block')); }
        });
    }

    // ---- header collapse/expand ----
    function setHeaderCollapsed($block, collapsed) {
        $block.toggleClass('collapsed', !!collapsed);
    }

    // ---- header add / remove ----
    function addHeaderBlock(name, serverId) {
        headerSeq++;
        var $block = renderHeaderBlock(headerSeq, name, serverId);
        $('#headerContainer').append($block);
        wireDropzone($block.find('.dropzone'));
        updateHeaderFieldCount($block);
        $block.find('.header-toggle').on('click', function () {
            setHeaderCollapsed($block, !$block.hasClass('collapsed'));
        });
        $block.find('.remove-header').on('click', function () {
            if ($block.hasClass('access-locked')) return; // Header Access: read-only for this user
            if (confirm('Remove this header and all its fields?')) {
                $block.find('.field-row').each(function () {
                    releaseFieldKey($(this).data('field-key'));
                });
                $block.remove();
                updateTotalFieldCount();
            }
        });
        return $block;
    }

    $('#btnAddHeader').on('click', function () {
        addHeaderBlock('New Header', '');
    });

    $('#btnExpandAllHeaders').on('click', function (e) {
        e.preventDefault();
        $('#headerContainer .header-block').each(function () { setHeaderCollapsed($(this), false); });
    });
    $('#btnCollapseAllHeaders').on('click', function (e) {
        e.preventDefault();
        $('#headerContainer .header-block').each(function () { setHeaderCollapsed($(this), true); });
    });

    // start with one header so the canvas isn't empty
    addHeaderBlock('New Header', '');

    // ---- collect the whole builder state into the DTO the server expects ----
    function buildTemplateDto() {
        var dto = {
            templateId: currentTemplateId,
            templateName: $('#txtTemplateName').val().trim(),
            type: currentType,
            customerNames: $('#lstParties option').map(function () { return $(this).val(); }).get(),
            headers: []
        };

        $('#headerContainer .header-block').each(function (hIdx) {
            var $h = $(this);
            var header = {
                headerId: parseInt($h.data('server-id'), 10) || 0,
                headerName: $h.find('.header-name').val().trim() || ('Header ' + (hIdx + 1)),
                displayOrder: hIdx + 1,
                fields: []
            };
            $h.find('.field-row').each(function (fIdx) {
                var $f = $(this);
                header.fields.push({
                    fieldId: parseInt($f.data('server-id'), 10) || 0,
                    fieldName: $f.data('source-column') || $f.find('.label-edit').val(),
                    fieldLabel: $f.find('.label-edit').val(),
                    fieldType: $f.find('.type-select').val(),
                    sourceType: $f.data('source-type'),
                    sourceTable: $f.data('source-table') || null,
                    sourceColumn: $f.data('source-column') || null,
                    dropdownOptions: $f.find('.dropdown-opts').val() || null,
                    isRequired: $f.find('.required-flag').is(':checked'),
                    displayOrder: fIdx + 1,
                    formulaOperation: $f.data('formula-op') || null,
                    formulaSources: $f.data('formula-sources') || null
                });
            });
            dto.headers.push(header);
        });

        // Headers this user has no access to are still rendered (just locked -
        // see applyHeaderAccessLock), so their disabled inputs read back their
        // original loaded values unchanged here same as any other header;
        // nothing special to do for them.
        return dto;
    }

    // ---- Save Template (top button): the single save action for all three
    // tabs. Template Fields is always saved; Report Settings is saved right
    // after (using whatever's currently in that tab's DOM - empty/default
    // when it was never touched); Template Settings' header access is saved
    // too, but only if at least one user is selected there (it's an optional
    // per-user restriction, so nothing to persist when unconfigured). All
    // three are validated up front so a mistake in one tab doesn't leave the
    // others partially saved.
    $('#btnSave').on('click', function () {
        var dto = buildTemplateDto();
        if (!dto.templateName) { alert('Template name is required.'); return; }
        if (dto.headers.length === 0) { alert('Add at least one header.'); return; }
        if (dto.customerNames.length === 0) {
            alert('Add at least one ' + (dto.type === 'Export' ? 'exporter' : 'importer') + ' name before saving. Every template must be tied to a client.');
            return;
        }

        var reportCheck = buildReportSettingsDto(currentTemplateId);
        if (reportCheck.error) { alert(reportCheck.error); return; }

        $('#lblStatus').text('Saving...');
        $.ajax({
            type: 'POST',
            url: 'TemplateBuilder.aspx/SaveTemplate',
            contentType: 'application/json',
            data: JSON.stringify({ templateJson: JSON.stringify(dto) }),
            success: function (res) {
                currentTemplateId = res.d;

                saveReportSettings(currentTemplateId, function () {
                    saveHeaderAccess(currentTemplateId, function () {
                        // Everything currently on screen has just been written to the
                        // database (Template Fields, Report Settings, Header Access),
                        // so - unlike a plain tab switch, which deliberately skips
                        // re-fetching (see the rsLoadedTemplateId/tsLoadedTemplateId
                        // guards below) so it never wipes unsaved edits - it's both
                        // safe and necessary to reload here: it confirms the save
                        // actually round-tripped and picks up any new HeaderID/FieldID
                        // values the server just assigned (new headers/fields), which
                        // the Headers checklist and Report Settings dropdowns need to
                        // reference correctly.
                        rsLoadedTemplateId = null;
                        refreshReportTabLock();
                        resyncTemplateSettingsAfterSave();

                        $('#lblStatus').text('Saved. Template ID: ' + currentTemplateId);
                        alert('Template saved successfully.');
                        loadTemplates();
                    });
                });
            },
            error: function (xhr) {
                var msg = 'Error saving template.';
                try { msg = JSON.parse(xhr.responseText).Message || msg; } catch (e) { }
                $('#lblStatus').text(msg);
                alert(msg);
                console.error(xhr.responseText);
            }
        });
    });

    // ---- created-templates grid: Edit loads it back into the builder, Report opens the popup ----
    function loadTemplates() {
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/GetTemplates',
            contentType: 'application/json', data: '{}',
            success: function (res) {
                var $body = $('#templatesBody').empty();
                $('#tplCount').text((res.d || []).length);

                if (!res.d || res.d.length === 0) {
                    $body.append('<tr><td colspan="4" class="templates-empty">No templates created yet.</td></tr>');
                    return;
                }
                $.each(res.d, function (i, t) {
                    var typeClass = (t.Type || '').toLowerCase() === 'export' ? 'export' : 'import';
                    var $typeBadge = $('<span class="type-badge">').addClass(typeClass).text(t.Type || '');

                    var $editLink = $('<a href="#" class="btn-mini btn-edit">').text('Edit').on('click', function (e) {
                        e.preventDefault();
                        loadTemplateForEdit(t.TemplateID);
                    });
                    var $reportLink = $('<a href="#" class="btn-mini btn-report">').text('Report').on('click', function (e) {
                        e.preventDefault();
                        openCenteredPopup(
                            'TemplateReport.aspx?TemplateID=' + t.TemplateID,
                            'templateReport_' + t.TemplateID,
                            1450, 750
                        );
                    });
                    var $deleteLink = $('<a href="#" class="btn-mini btn-delete">').text('Delete').on('click', function (e) {
                        e.preventDefault();
                        if (!confirm('Delete template "' + t.TemplateName + '"? This cannot be undone.')) return;
                        $.ajax({
                            type: 'POST', url: 'TemplateBuilder.aspx/DeleteTemplate',
                            contentType: 'application/json',
                            data: JSON.stringify({ templateId: t.TemplateID }),
                            success: function () {
                                alert('Template deleted.');
                                if (currentTemplateId === t.TemplateID) resetForm();
                                loadTemplates();
                            },
                            error: function (xhr) {
                                alert('Could not delete template.');
                                console.error(xhr.responseText);
                            }
                        });
                    });
                    var $row = $('<tr>');
                    $row.append($('<td class="sno-col">').text(i + 1));
                    $row.append($('<td>').text(t.TemplateName));
                    $row.append($('<td>').append($typeBadge));
                    $row.append($('<td class="actions-col">').append($editLink).append($reportLink).append($deleteLink));
                    $body.append($row);
                });
            },
            error: function (xhr) {
                $('#templatesBody').empty().append('<tr><td colspan="4" class="templates-empty">Error loading templates.</td></tr>');
                console.error(xhr.responseText);
            }
        });
    }

    // ---- Edit: pull the full template graph back into the builder UI ----
    function loadTemplateForEdit(templateId) {
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/GetTemplateDetail',
            contentType: 'application/json',
            data: JSON.stringify({ templateId: templateId }),
            success: function (res) {
                var detail = res.d;
                currentTemplateId = detail.templateId;

                $('#txtTemplateName').val(detail.templateName);
                $('#ddlType').val(detail.type || 'Import').trigger('change');

                $('#lstParties').empty();
                $.each(detail.customerNames || [], function (i, name) {
                    $('#lstParties').append($('<option>').val(name).text(name));
                });

                $('#headerContainer').empty();
                resetUsedFieldTracking();

                $.ajax({
                    type: 'POST', url: 'TemplateBuilder.aspx/GetAllowedHeaderIdsForCurrentUser',
                    contentType: 'application/json',
                    data: JSON.stringify({ templateId: detail.templateId }),
                    success: function (allowedRes) {
                        renderTemplateHeadersForEdit(detail, allowedRes.d);
                    },
                    error: function (xhr) {
                        // Can't determine restrictions - fail open (show everything
                        // unlocked) rather than locking headers over a transient error.
                        console.error(xhr.responseText);
                        renderTemplateHeadersForEdit(detail, null);
                    }
                });
            },
            error: function (xhr) {
                alert('Could not load template for editing.');
                console.error(xhr.responseText);
            }
        });
    }

    // Renders every header (per allowedHeaderIds - null means full access) -
    // one the current user has no Header Access to still shows on the canvas,
    // just locked (see applyHeaderAccessLock): a "No Access" badge on its
    // title, every field disabled, and dragging into/out of it blocked. Its
    // disabled inputs still read back their original values unchanged in
    // buildTemplateDto(), so nothing is lost when this user saves the template.
    function renderTemplateHeadersForEdit(detail, allowedHeaderIds) {
        var lockedCount = 0;

        $.each(detail.headers || [], function (i, header) {
            var isAllowed = allowedHeaderIds === null || $.inArray(header.headerId, allowedHeaderIds) > -1;

            var $block = addHeaderBlock(header.headerName, header.headerId);
            var $zone = $block.find('.dropzone');
            $.each(header.fields || [], function (j, field) {
                fieldSeq++;
                var $row = renderFieldRow({
                    key: 'f' + fieldSeq,
                    serverId: field.fieldId,
                    label: field.fieldLabel,
                    sourceType: field.sourceType,
                    sourceTable: field.sourceTable,
                    sourceColumn: field.sourceColumn,
                    type: field.fieldType,
                    options: field.dropdownOptions,
                    required: field.isRequired,
                    formulaOperation: field.formulaOperation,
                    formulaSources: field.formulaSources
                });
                var key = fieldKeyFor(field.sourceType, field.sourceTable, field.sourceColumn);
                $row.attr('data-field-key', key);
                usedFieldKeys[key] = true;
                $zone.append($row);
            });

            if (!isAllowed) {
                lockedCount++;
                applyHeaderAccessLock($block);
            }
        });

        if (!detail.headers || detail.headers.length === 0) {
            addHeaderBlock('New Header', '');
        }
        updateAllFieldCounts();

        $('#lblStatus').text('Editing: ' + detail.templateName);
        if (lockedCount > 0) {
            alert('Loaded "' + detail.templateName + '" for editing. ' + lockedCount +
                ' header(s) are read-only because you do not have access to them.');
        } else {
            alert('Loaded "' + detail.templateName + '" for editing.');
        }
        // force a fresh fetch even if this is the same templateId already
        // sitting in the tabs - Edit means "discard anything unsaved and
        // reload from the server", unlike a plain tab switch.
        rsLoadedTemplateId = null;
        tsLoadedTemplateId = null;
        refreshReportTabLock();
        refreshTemplateSettingsTabLock();
    }

    // Template Settings tab -> Header Access: marks a header block read-only
    // for the current user - same "show it, but disable it" language
    // DSREntry.aspx already uses for its own header titles/fields. Disables
    // every field control and the header name/remove actions, and blocks
    // dragging fields into or out of this header (see wireDropzone's accept
    // check and the connectWith exclusion below).
    function applyHeaderAccessLock($block) {
        $block.addClass('access-locked');
        $block.find('.remove-header').before('<span class="header-no-access">No Access</span>');
        $block.find('.header-name').prop('disabled', true);
        $block.find('.field-row').each(function () {
            var $row = $(this);
            $row.addClass('locked');
            $row.find('.label-edit, .type-select, .dropdown-opts, .required-flag').prop('disabled', true);
        });
    }

    // ---- New Template: discard whatever is loaded and start fresh ----
    function resetForm() {
        currentTemplateId = 0;
        $('#txtTemplateName').val('');
        $('#lstParties').empty();
        $('#headerContainer').empty();
        resetUsedFieldTracking();
        addHeaderBlock('New Header', '');
        updateTotalFieldCount();
        $('#ddlType').val('Import').trigger('change');
        $('#lblStatus').text('');
        refreshReportTabLock();
        refreshTemplateSettingsTabLock();
    }

    $('#btnNewTemplate').on('click', resetForm);

    // ---- Cancel: back to the main portal, same target as every other module's
    // cancelButt link (e.g. Accounts_Master/Bank_Master_Search.aspx). This page
    // renders inside the portal's frameset, so navigate window.top (not just
    // this frame) to actually leave the module rather than reloading inside it.
    $('#btnCancel').on('click', function () {
        window.top.location.href = '../LoginPage/E_royal_Impex_Main.aspx';
    });

    // ======================================================================
    // Report Settings tab: Filters / Group & Sort / Calculate & Summarize /
    // Format & Schedule (Access & Sharing). Operates on whichever template
    // is currently loaded in the builder (currentTemplateId); requires the
    // template to already be saved, since filters/group/sort/summary rows
    // reference real DSR_TemplateField.FieldID values.
    // ======================================================================
    var rsFields = [];   // [{fieldId, label, fieldType, sourceType}]

    // ---- Report Settings sections: collapse/expand, same idea as the
    // Template Fields headers' Expand All/Collapse All ----
    $('.rs-section h4').each(function () {
        $(this).prepend('<span class="section-toggle">&#9660;</span>');
    });
    $('.rs-section h4').on('click', function () {
        $(this).closest('.rs-section').toggleClass('collapsed');
    });
    $('#btnExpandAllSections').on('click', function (e) {
        e.preventDefault();
        $('.rs-section').removeClass('collapsed');
    });
    $('#btnCollapseAllSections').on('click', function (e) {
        e.preventDefault();
        // the trailing "Save Report Settings" bar has no <h4>, so it's never
        // matched by the .rs-section h4 selector above and stays uncollapsible
        $('.rs-section').has('h4').addClass('collapsed');
    });

    var tabPanelIdByTab = { fields: 'Fields', report: 'Report', templateSettings: 'TemplateSettings' };
    $('.tab-btn').on('click', function () {
        var tab = $(this).data('tab');
        $('.tab-btn').removeClass('active');
        $(this).addClass('active');
        $('.tab-panel').removeClass('active');
        $('#tabPanel' + (tabPanelIdByTab[tab] || 'Fields')).addClass('active');
        if (tab === 'report') refreshReportTabLock();
        if (tab === 'templateSettings') refreshTemplateSettingsTabLock();
    });

    // Which templateId's data is currently sitting in the Report Settings /
    // Template Settings DOM - null means "nothing loaded yet". Guards against
    // refetching from the server (and blowing away unsaved edits) every time
    // the user merely switches tabs; a fresh load only happens the first time
    // a given template's tab is opened, or when loadTemplateForEdit/resetForm
    // explicitly clear the flag because the loaded template actually changed.
    var rsLoadedTemplateId = null;
    var tsLoadedTemplateId = null;

    function refreshReportTabLock() {
        if (currentTemplateId > 0) {
            $('#reportSettingsLocked').hide();
            $('#reportSettingsBody').show();
            if (rsLoadedTemplateId !== currentTemplateId) {
                loadReportSettings();
                rsLoadedTemplateId = currentTemplateId;
            }
        } else {
            $('#reportSettingsLocked').show();
            $('#reportSettingsBody').hide();
            rsLoadedTemplateId = null;
        }
    }

    // ======================================================================
    // Template Settings tab: per-header user access (DSR_TemplateHeaderAccess -
    // see TemplateBuilder.aspx.cs / DSR_TemplateHeaderAccess_Schema.sql).
    // Restricts which of the template's headers a user may access when
    // entering custom field data (DSREntry.aspx). Same "locked until saved"
    // pattern as Report Settings.
    //
    // Header-first workflow: pick ONE header from the dropdown, then check
    // which of every known user may access it. Every user's full access
    // state for every header is fetched once (tsUserAccessState) so
    // switching the dropdown between headers is instant with no extra AJAX;
    // edits only change tsUserAccessState in memory (tracking who's dirty in
    // tsDirtyUsers) and are sent to the server solely by the top Save
    // Template button (see saveHeaderAccess), one SaveHeaderAccess call per
    // changed user since each can end up with a different resulting set.
    //
    // A user who has never been restricted on ANY header of this template
    // (configured=false) has full access to everything by default (see the
    // schema doc) - unchecking them for a header for the first time is what
    // converts them into an explicit set (every other header, minus this
    // one), matching that same convention.
    // ======================================================================
    var tsUsersLoaded = false;
    var tsAllUsers = [];          // every username from GetUsers(), loaded once
    var tsHeaders = [];           // [{headerId, headerName, displayOrder}]
    var tsUserAccessState = {};   // { userName: { configured: bool, headerIds: [int,...] } }
    var tsSelectedHeaderId = null; // headerId currently chosen in the dropdown
    var tsDirtyUsers = {};         // set (object) of usernames changed in memory, pending Save

    function refreshTemplateSettingsTabLock() {
        if (currentTemplateId > 0) {
            $('#templateSettingsLocked').hide();
            $('#templateSettingsBody').show();
            if (tsLoadedTemplateId !== currentTemplateId) {
                tsDirtyUsers = {};
                tsSelectedHeaderId = null;
                $('#ddlAccessHeaderName').val('');
                $('#headerUserAccessSection').hide();
                $('#headerAccessNoHeaderNotice').show();
                loadTemplateSettingsHeaders();
                tsLoadedTemplateId = currentTemplateId;
            }
        } else {
            $('#templateSettingsLocked').show();
            $('#templateSettingsBody').hide();
            tsLoadedTemplateId = null;
        }
    }

    // Post-save resync (called from btnSave's success handler instead of
    // refreshTemplateSettingsTabLock): refreshes the Headers dropdown and
    // every user's access state from the server - safe to do unconditionally
    // here since saveHeaderAccess() has already cleared tsDirtyUsers by the
    // time this runs, so there's nothing in-memory left to lose. Keeps
    // whichever header is currently selected instead of resetting the
    // dropdown, so the admin doesn't lose their place after Save.
    function resyncTemplateSettingsAfterSave() {
        if (currentTemplateId <= 0) return;
        $('#templateSettingsLocked').hide();
        $('#templateSettingsBody').show();
        loadTemplateSettingsHeaders();
    }

    // Loads the Headers dropdown, then (once) the full user list, then every
    // user's current access state in a single batch - see tsUserAccessState.
    function loadTemplateSettingsHeaders() {
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/GetTemplateHeaders',
            contentType: 'application/json',
            data: JSON.stringify({ templateId: currentTemplateId }),
            success: function (res) {
                tsHeaders = res.d || [];
                renderHeaderNameDropdown();
                if (!tsUsersLoaded) {
                    loadTemplateSettingsUsers();
                } else {
                    loadAllUsersAccessState();
                }
            },
            error: function (xhr) {
                console.error(xhr.responseText);
            }
        });
    }

    function renderHeaderNameDropdown() {
        var $ddl = $('#ddlAccessHeaderName').empty().append('<option value="">-- choose header --</option>');
        $.each(tsHeaders, function (i, h) {
            $ddl.append($('<option>').val(h.headerId).text(h.headerName));
        });
        if (tsSelectedHeaderId) $ddl.val(tsSelectedHeaderId);
        $('#headerAccessEmpty').toggle(tsHeaders.length === 0);
    }

    function loadTemplateSettingsUsers() {
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/GetUsers',
            contentType: 'application/json', data: '{}',
            success: function (res) {
                tsUsersLoaded = true;
                tsAllUsers = res.d || [];
                loadAllUsersAccessState();
            },
            error: function (xhr) {
                console.error(xhr.responseText);
            }
        });
    }

    function loadAllUsersAccessState() {
        tsUserAccessState = {};
        if (tsAllUsers.length === 0) { renderHeaderUserAccessList(); return; }
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/GetHeaderAccessForUsers',
            contentType: 'application/json',
            data: JSON.stringify({ templateId: currentTemplateId, userNames: tsAllUsers }),
            success: function (res) {
                $.each(res.d || [], function (i, e) {
                    tsUserAccessState[e.userName] = { configured: e.configured, headerIds: (e.headerIds || []).slice() };
                });
                renderHeaderUserAccessList();
            },
            error: function (xhr) {
                console.error(xhr.responseText);
            }
        });
    }

    function userHasHeaderAccess(userName, headerId) {
        var state = tsUserAccessState[userName];
        if (!state || !state.configured) return true; // never configured -> full access
        return $.inArray(headerId, state.headerIds) > -1;
    }

    $('#ddlAccessHeaderName').on('change', function () {
        tsSelectedHeaderId = parseInt($(this).val(), 10) || null;
        $('#headerUserAccessSection').toggle(!!tsSelectedHeaderId);
        $('#headerAccessNoHeaderNotice').toggle(!tsSelectedHeaderId);
        renderHeaderUserAccessList();
    });

    function renderHeaderUserAccessList() {
        var $list = $('#headerUserAccessList').empty();
        if (!tsSelectedHeaderId) return;
        $.each(tsAllUsers, function (i, userName) {
            var $row = $('<label class="header-access-row">');
            var $chk = $('<input type="checkbox" class="header-user-access-chk">').val(userName);
            $chk.prop('checked', userHasHeaderAccess(userName, tsSelectedHeaderId));
            $row.append($chk).append(' ' + userName);
            $list.append($row);
        });
    }

    // Checking/unchecking a user for the currently selected header updates
    // tsUserAccessState in memory only - nothing hits the server until the
    // top Save Template button runs (see saveHeaderAccess below). A user who
    // was never configured (full access to everything) only gets converted
    // into an explicit set the first time they're UNCHECKED for some header;
    // checking them while they already have full access is a no-op.
    $('#headerUserAccessList').on('change', '.header-user-access-chk', function () {
        var userName = $(this).val();
        var checked = this.checked;
        var headerId = tsSelectedHeaderId;
        if (!headerId) return;

        var state = tsUserAccessState[userName];
        if (!state || !state.configured) {
            if (checked) return; // already has full access, nothing to change
            var allExceptThis = $.map(tsHeaders, function (h) { return h.headerId; })
                .filter(function (id) { return id !== headerId; });
            tsUserAccessState[userName] = { configured: true, headerIds: allExceptThis };
        } else {
            var ids = state.headerIds;
            var pos = $.inArray(headerId, ids);
            if (checked && pos === -1) ids.push(headerId);
            if (!checked && pos > -1) ids.splice(pos, 1);
        }
        tsDirtyUsers[userName] = true;
    });

    // Called from the top Save Template button. Persists every user whose
    // header access changed in memory this session - one SaveHeaderAccess
    // call per changed user, since each may end up with a different
    // resulting header set. Skips entirely if nothing was touched.
    // `done(errorMessageOrNull)` always fires so the caller can chain the
    // next step regardless of outcome.
    function saveHeaderAccess(templateId, done) {
        var dirtyUsers = Object.keys(tsDirtyUsers);
        if (dirtyUsers.length === 0) { done(null); return; }

        $('#lblHeaderAccessStatus').text('Saving...');
        var remaining = dirtyUsers.length;
        var firstError = null;

        $.each(dirtyUsers, function (i, userName) {
            var state = tsUserAccessState[userName];
            $.ajax({
                type: 'POST', url: 'TemplateBuilder.aspx/SaveHeaderAccess',
                contentType: 'application/json',
                data: JSON.stringify({ templateId: templateId, userNames: [userName], headerIds: state.headerIds }),
                complete: function (xhr) {
                    if (xhr.status >= 400 && !firstError) {
                        try { firstError = JSON.parse(xhr.responseText).Message; } catch (e) { }
                        firstError = firstError || 'Error saving header access.';
                        console.error(xhr.responseText);
                    }
                    remaining--;
                    if (remaining === 0) {
                        tsDirtyUsers = {};
                        $('#lblHeaderAccessStatus').text(firstError || 'Saved.');
                        done(firstError);
                    }
                }
            });
        });
    }

    function fieldOptionsHtml(selectedFieldId) {
        var html = '';
        $.each(rsFields, function (i, f) {
            html += '<option value="' + f.fieldId + '"' + (f.fieldId === selectedFieldId ? ' selected' : '') + '>' + $('<div>').text(f.label).html() + '</option>';
        });
        return html;
    }

    var filterOperators = [
        { value: 'Equals', text: 'Equals' },
        { value: 'NotEquals', text: 'Not Equals' },
        { value: 'Contains', text: 'Contains' },
        { value: 'NotContains', text: 'Not Contains' },
        { value: 'IsOneOf', text: 'Is one of' },
        { value: 'IsEmpty', text: 'Is Empty' },
        { value: 'IsNotEmpty', text: 'Is Not Empty' }
    ];

    function addFilterRow(filter) {
        filter = filter || {};
        var $row = $('<div class="rs-row">');
        var $field = $('<select class="rs-field">').html(fieldOptionsHtml(filter.fieldId));
        var $op = $('<select class="rs-op">');
        $.each(filterOperators, function (i, o) {
            $op.append($('<option>').val(o.value).text(o.text));
        });
        if (filter.op) $op.val(filter.op);
        var $value = $('<input type="text" class="rs-value" placeholder="Value">').val(filter.filterValue || '');
        var $remove = $('<span class="rs-remove">&#10005;</span>').on('click', function () { $row.remove(); });

        function syncValueVisibility() {
            var op = $op.val();
            var needsValue = (op !== 'IsEmpty' && op !== 'IsNotEmpty');
            $value.toggle(needsValue);
            $value.attr('placeholder', op === 'IsOneOf' ? 'Value1,Value2,Value3' : 'Value');
        }
        $op.on('change', syncValueVisibility);
        syncValueVisibility();

        $row.append($field).append($op).append($value).append($remove);
        $('#filterList').append($row);
    }

    function addGroupRow(group) {
        group = group || {};
        var $row = $('<div class="rs-row">');
        var $field = $('<select class="rs-field">').html(fieldOptionsHtml(group.fieldId));
        var $remove = $('<span class="rs-remove">&#10005;</span>').on('click', function () { $row.remove(); });
        $row.append($field).append($remove);
        $('#groupList').append($row);
    }

    function addSortRow(sort) {
        sort = sort || {};
        var $row = $('<div class="rs-row">');
        var $field = $('<select class="rs-field">').html(fieldOptionsHtml(sort.fieldId));
        var $dir = $('<select class="rs-op">').append('<option value="Asc">Ascending</option>').append('<option value="Desc">Descending</option>');
        if (sort.direction) $dir.val(sort.direction);
        var $remove = $('<span class="rs-remove">&#10005;</span>').on('click', function () { $row.remove(); });
        $row.append($field).append($dir).append($remove);
        $('#sortList').append($row);
    }

    $('#btnAddFilter').on('click', function () { addFilterRow(); });
    $('#btnAddGroup').on('click', function () { addGroupRow(); });
    $('#btnAddSort').on('click', function () { addSortRow(); });

    // Date Comparison: only Date-type fields make sense as either side of a
    // day-difference comparison.
    function dateFieldOptionsHtml(selectedFieldId) {
        var html = '';
        $.each(rsFields, function (i, f) {
            if (f.fieldType !== 'Date') return;
            html += '<option value="' + f.fieldId + '"' + (f.fieldId === selectedFieldId ? ' selected' : '') + '>' + $('<div>').text(f.label).html() + '</option>';
        });
        return html;
    }

    function addDateDiffRow(dateDiff) {
        dateDiff = dateDiff || {};
        var $row = $('<div class="rs-row">');
        var $label = $('<input type="text" class="dd-label" placeholder="New field name, e.g. Days Between Invoice and Delivery">').val(dateDiff.label || '');
        var $from = $('<select class="dd-from rs-field">').html(dateFieldOptionsHtml(dateDiff.fromFieldId));
        var $arrow = $('<span class="dd-arrow">&#8594;</span>');
        var $to = $('<select class="dd-to rs-field">').html(dateFieldOptionsHtml(dateDiff.toFieldId));
        var $remove = $('<span class="rs-remove">&#10005;</span>').on('click', function () { $row.remove(); });
        $row.append($label).append($from).append($arrow).append($to).append($remove);
        $('#dateDiffList').append($row);
    }

    $('#btnAddDateDiff').on('click', function () {
        var dateFieldCount = 0;
        $.each(rsFields, function (i, f) { if (f.fieldType === 'Date') dateFieldCount++; });
        if (dateFieldCount < 2) {
            alert('Add at least two Date fields to the template before configuring a Date Comparison.');
            return;
        }
        addDateDiffRow();
    });

    // Invoice Slno / Item Slno identify one specific line within a job (not a
    // value to total), so the first time a field like this shows up in
    // Calculate & Summarize - i.e. no DSR_ReportSummary row saved for it yet -
    // default its operation to MIN instead of None. Matches on the field label
    // with everything but letters stripped, so "ITEM_SLNO", "Item Slno" and
    // "ItemSlno" all match the same way regardless of how the field was labeled.
    function isSlnoDefaultMinField(label) {
        var normalized = (label || '').toLowerCase().replace(/[^a-z]/g, '');
        return normalized === 'itemslno' || normalized === 'invoiceslno';
    }

    function renderSummaryList(summaries) {
        var opByFieldId = {};
        $.each(summaries || [], function (i, s) { opByFieldId[s.fieldId] = s.operation; });

        var $list = $('#summaryList').empty();
        var summaryOps = ['None', 'SUM', 'AVG', 'MIN', 'MAX', 'COUNT'];
        $.each(rsFields, function (i, f) {
            var $row = $('<div class="rs-row">');
            $row.append($('<span style="min-width:220px;">').text(f.label));
            var $op = $('<select class="rs-op" data-field-id="' + f.fieldId + '">');
            $.each(summaryOps, function (j, op) { $op.append($('<option>').val(op).text(op)); });
            var defaultOp = isSlnoDefaultMinField(f.label) ? 'MIN' : 'None';
            $op.val(opByFieldId.hasOwnProperty(f.fieldId) ? opByFieldId[f.fieldId] : defaultOp);
            $row.append($op);
            $list.append($row);
        });
    }

    function renderAccess(access) {
        access = access || { accessMode: 'Everyone' };
        $('input[name=accessMode][value=' + access.accessMode + ']').prop('checked', true);
        $('#roleAssignBox').toggle(access.accessMode === 'SpecificRole');
        loadRoles(function () {
            if (access.roleId) {
                $('#ddlAccessRole').val(access.roleId);
                loadRoleMembers(access.roleId);
            }
        });
    }

    $('input[name=accessMode]').on('change', function () {
        var mode = $(this).val();
        $('#roleAssignBox').toggle(mode === 'SpecificRole');
        if (mode === 'SpecificRole') loadRoles();
    });

    // #ddlScheduleDayOfMonth's 31 options are the same every time, so build
    // them once instead of via markup.
    (function populateDayOfMonth() {
        var $ddl = $('#ddlScheduleDayOfMonth');
        for (var d = 1; d <= 31; d++) {
            $ddl.append($('<option>').val(d).text(d));
        }
    })();

    // Day-of-week/Date-of-month only make sense for their matching frequency;
    // Time applies to all three.
    function syncScheduleFrequencyFields() {
        var freq = $('#ddlScheduleFrequency').val();
        $('#scheduleDayOfWeekBox').toggle(freq === 'Weekly');
        $('#scheduleDayOfMonthBox').toggle(freq === 'Monthly');
    }

    function renderSchedule(schedule) {
        schedule = schedule || { isEnabled: false, frequency: 'Daily', scheduleTime: '09:00', dayOfWeek: 1, dayOfMonth: 1, recipientEmails: '' };
        $('#chkScheduleEnabled').prop('checked', !!schedule.isEnabled);
        $('#ddlScheduleFrequency').val(schedule.frequency || 'Daily');
        $('#txtScheduleTime').val(schedule.scheduleTime || '09:00');
        $('#ddlScheduleDayOfWeek').val(schedule.dayOfWeek != null ? schedule.dayOfWeek : 1);
        $('#ddlScheduleDayOfMonth').val(schedule.dayOfMonth != null ? schedule.dayOfMonth : 1);
        $('#txtScheduleRecipients').val(schedule.recipientEmails || '');
        $('#scheduleOptionsBox').toggle(!!schedule.isEnabled);
        syncScheduleFrequencyFields();
    }

    $('#chkScheduleEnabled').on('change', function () {
        $('#scheduleOptionsBox').toggle($(this).is(':checked'));
    });

    $('#ddlScheduleFrequency').on('change', syncScheduleFrequencyFields);

    function loadRoles(after) {
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/GetRoles',
            contentType: 'application/json', data: '{}',
            success: function (res) {
                var $ddl = $('#ddlAccessRole').empty();
                $.each(res.d || [], function (i, r) {
                    $ddl.append($('<option>').val(r.roleId).text(r.roleName));
                });
                if (typeof after === 'function') after();
            }
        });
    }

    $('#ddlAccessRole').on('change', function () {
        var roleId = parseInt($(this).val(), 10);
        if (roleId) loadRoleMembers(roleId);
    });

    function loadRoleMembers(roleId) {
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/GetRoleMembers',
            contentType: 'application/json',
            data: JSON.stringify({ roleId: roleId }),
            success: function (res) {
                $('#txtRoleMembers').val((res.d || []).join('\n'));
            }
        });
    }

    $('#btnCreateRole').on('click', function () {
        var name = $('#txtNewRoleName').val().trim();
        if (!name) { alert('Enter a role name first.'); return; }
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/CreateRole',
            contentType: 'application/json',
            data: JSON.stringify({ roleName: name }),
            success: function (res) {
                loadRoles(function () {
                    $('#ddlAccessRole').val(res.d.roleId);
                    $('#txtRoleMembers').val('');
                });
                $('#txtNewRoleName').val('');
            },
            error: function (xhr) { alert('Could not create role.'); console.error(xhr.responseText); }
        });
    });

    $('#btnSaveRoleMembers').on('click', function () {
        var roleId = parseInt($('#ddlAccessRole').val(), 10);
        if (!roleId) { alert('Choose or create a role first.'); return; }
        var userNames = $('#txtRoleMembers').val().split('\n')
            .map(function (s) { return s.trim(); })
            .filter(function (s) { return s.length > 0; });
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/SaveRoleMembers',
            contentType: 'application/json',
            data: JSON.stringify({ roleId: roleId, userNames: userNames }),
            success: function () { alert('Role members saved.'); },
            error: function (xhr) { alert('Could not save role members.'); console.error(xhr.responseText); }
        });
    });

    function loadReportSettings() {
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/GetReportSettings',
            contentType: 'application/json',
            data: JSON.stringify({ templateId: currentTemplateId }),
            success: function (res) {
                var d = res.d;
                rsFields = d.fields || [];

                $('#filterList').empty();
                $.each(d.filters || [], function (i, f) { addFilterRow(f); });

                $('#groupList').empty();
                $.each(d.groups || [], function (i, g) { addGroupRow(g); });

                $('#sortList').empty();
                $.each(d.sorts || [], function (i, s) { addSortRow(s); });

                renderSummaryList(d.summaries);

                $('#dateDiffList').empty();
                $.each(d.dateDiffs || [], function (i, dd) { addDateDiffRow(dd); });

                renderAccess(d.access);
                renderSchedule(d.schedule);

                $('#lblReportSettingsStatus').text('');
            },
            error: function (xhr) {
                $('#lblReportSettingsStatus').text('Error loading report settings.');
                console.error(xhr.responseText);
            }
        });
    }

    // Reads the Report Settings tab's current DOM state into the DTO the
    // server expects, validating the Date Comparison rows along the way.
    // Called from the top Save Template button - once before SaveTemplate
    // runs (templateId passed as 0/whatever's current, purely to validate
    // without alerting mid-save) and once after (with the real templateId).
    // Returns { dto } on success or { error } on a validation failure.
    function buildReportSettingsDto(templateId) {
        var dateDiffs = $('#dateDiffList .rs-row').map(function () {
            var $r = $(this);
            return {
                label: $r.find('.dd-label').val().trim(),
                fromFieldId: parseInt($r.find('.dd-from').val(), 10),
                toFieldId: parseInt($r.find('.dd-to').val(), 10)
            };
        }).get();

        for (var i = 0; i < dateDiffs.length; i++) {
            if (!dateDiffs[i].label) return { error: 'Enter a field name for every Date Comparison row.' };
            if (!dateDiffs[i].fromFieldId || !dateDiffs[i].toFieldId) return { error: 'Choose both a From Date and a To Date for every Date Comparison row.' };
            if (dateDiffs[i].fromFieldId === dateDiffs[i].toFieldId) return { error: '"' + dateDiffs[i].label + '": From Date and To Date must be different fields.' };
        }

        var dto = {
            templateId: templateId,
            dateDiffs: dateDiffs,
            filters: $('#filterList .rs-row').map(function () {
                var $r = $(this);
                var op = $r.find('.rs-op').val();
                return {
                    fieldId: parseInt($r.find('.rs-field').val(), 10),
                    op: op,
                    filterValue: (op === 'IsEmpty' || op === 'IsNotEmpty') ? null : $r.find('.rs-value').val()
                };
            }).get(),
            groups: $('#groupList .rs-row').map(function () {
                return { fieldId: parseInt($(this).find('.rs-field').val(), 10) };
            }).get(),
            sorts: $('#sortList .rs-row').map(function () {
                var $r = $(this);
                return {
                    fieldId: parseInt($r.find('.rs-field').val(), 10),
                    direction: $r.find('.rs-op').val()
                };
            }).get(),
            summaries: $('#summaryList .rs-op').map(function () {
                var $s = $(this);
                return { fieldId: parseInt($s.data('field-id'), 10), operation: $s.val() };
            }).get(),
            access: {
                accessMode: $('input[name=accessMode]:checked').val() || 'Everyone',
                roleId: parseInt($('#ddlAccessRole').val(), 10) || null
            },
            schedule: {
                isEnabled: $('#chkScheduleEnabled').is(':checked'),
                frequency: $('#ddlScheduleFrequency').val() || 'Daily',
                scheduleTime: $('#txtScheduleTime').val() || '09:00',
                dayOfWeek: parseInt($('#ddlScheduleDayOfWeek').val(), 10),
                dayOfMonth: parseInt($('#ddlScheduleDayOfMonth').val(), 10),
                recipientEmails: $('#txtScheduleRecipients').val()
            }
        };
        return { dto: dto };
    }

    // Called from the top Save Template button, after SaveTemplate succeeds.
    // `done(errorMessageOrNull)` always fires so the caller can chain the
    // next step regardless of outcome.
    function saveReportSettings(templateId, done) {
        var built = buildReportSettingsDto(templateId);
        if (built.error) {
            // already validated before SaveTemplate ran, so this shouldn't
            // happen in practice - bail out the same way just in case.
            $('#lblReportSettingsStatus').text(built.error);
            done(built.error);
            return;
        }

        $('#lblReportSettingsStatus').text('Saving...');
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/SaveReportSettings',
            contentType: 'application/json',
            data: JSON.stringify({ settingsJson: JSON.stringify(built.dto) }),
            success: function () {
                $('#lblReportSettingsStatus').text('Report settings saved.');
                done(null);
            },
            error: function (xhr) {
                $('#lblReportSettingsStatus').text('Error saving report settings.');
                console.error(xhr.responseText);
                done('Error saving report settings.');
            }
        });
    }

    $('#btnTestScheduleEmail').on('click', function () {
        if (currentTemplateId <= 0) { alert('Save the template first.'); return; }
        var $btn = $(this);
        $btn.prop('disabled', true);
        $('#lblScheduleTestStatus').text('Sending...');
        $.ajax({
            type: 'POST', url: 'TemplateBuilder.aspx/SendTestScheduleEmail',
            contentType: 'application/json',
            data: JSON.stringify({ templateId: currentTemplateId }),
            success: function (res) {
                $('#lblScheduleTestStatus').text(res.d);
            },
            error: function (xhr) {
                var msg = 'Send failed.';
                try { msg = JSON.parse(xhr.responseText).Message || msg; } catch (e) { }
                $('#lblScheduleTestStatus').text(msg);
                console.error(xhr.responseText);
            },
            complete: function () { $btn.prop('disabled', false); }
        });
    });

    loadPartyNames();
    loadTables();
    loadTemplates();
});
})(window.TBQuery);
