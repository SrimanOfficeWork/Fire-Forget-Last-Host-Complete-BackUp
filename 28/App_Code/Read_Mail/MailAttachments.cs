using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MailAttachments
/// </summary>
public class MailAttachments
{
	public MailAttachments()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private int _MailMessageId;

    public int MailMessageId
    {
        get { return _MailMessageId; }
        set { _MailMessageId = value; }
    }

    private string _AttachmentName;

    public string AttachmentName
    {
        get { return _AttachmentName; }
        set { _AttachmentName = value; }
    }

    private string _AttachmentNewName;

    public string AttachmentNewName
    {
        get { return _AttachmentNewName; }
        set { _AttachmentNewName = value; }
    }
   
}
