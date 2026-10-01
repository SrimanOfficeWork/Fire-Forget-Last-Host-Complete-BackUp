using System.Collections.Generic;

public class BillOfEntry
{
    public string doc_type { get; set; }
    public BeHeader header { get; set; }
    public BeGeneralInfo general_info { get; set; }
    public List<BeInvoiceInfo> invoice_info { get; set; }
    public List<BeIgmsInfo> igms_info { get; set; }

    public List<BeItemsInfo> items_info { get; set; }
    public List<BeContainerInfo> container_info { get; set; }
    public List<BeItemSWInfoTypeInfo> swinfotype_info { get; set; }

    public BeExchangeInfo exchange_info { get; set; }

    public BillOfEntry()
    {
        invoice_info = new List<BeInvoiceInfo>();
        igms_info = new List<BeIgmsInfo>();
        items_info = new List<BeItemsInfo>();
        container_info = new List<BeContainerInfo>();
        swinfotype_info = new List<BeItemSWInfoTypeInfo>();
    }
}

public class BeHeader
{
    public string company_id { get; set; }
    public string file_type { get; set; }
    public string record_type { get; set; }
    public string sender_id_type { get; set; }
    public string sender_id { get; set; }
    public string receiver_id_type { get; set; }
    public string receiver_id { get; set; }
    public string version { get; set; }
    public string message_id { get; set; }
    public string sequence_no { get; set; }
    public string date { get; set; }
    public string time { get; set; }
}

public class BeGeneralInfo
{
    public string custom_house_code { get; set; }
    public string cha_license_no { get; set; }
    public string user_job_no { get; set; }
    public string user_job_date { get; set; }
    public string be_no { get; set; }
    public string be_date { get; set; }
    public string be_type { get; set; }
    public string icegate_user_id { get; set; }
    public string importer_exporter_code { get; set; }
    public string branch_sr_no_of_exporter { get; set; }
    public string importer_name { get; set; }
    public string importer_address_1 { get; set; }
    public string importer_address_2 { get; set; }
    public string importer_city { get; set; }
    public string importer_state { get; set; }
    public string importer_pin { get; set; }
    public string importer_class { get; set; }
    public string mode_of_transport { get; set; }
    public string importer_type { get; set; }
    public string kachcha_be { get; set; }
    public string high_sea_sale_flag { get; set; }
    public string port_of_origin { get; set; }
    public string cha_code { get; set; }
    public string country_of_origin { get; set; }
    public string country_of_consignment { get; set; }
    public string port_of_shipment { get; set; }
    public string green_channel_requested { get; set; }
    public string section_48_requested { get; set; }
    public string whether_prior_be { get; set; }
    public string authorized_dealer_code { get; set; }
    public string first_check_requested { get; set; }
    public string warehouse_code { get; set; }
    public string warehouse_customs_site_id { get; set; }
    public string warehouse_be_no { get; set; }
    public string warehouse_be_date { get; set; }
    public string no_of_packages_released { get; set; }
    public string package_code { get; set; }
    public string gross_weight { get; set; }
    public string unit_of_measurement { get; set; }
    public string loading_for_x_bond_over_wh_be { get; set; }
    public string miscellaneous_load_rate { get; set; }
}

public class BeInvoiceInfo
{
    public string custom_house_code { get; set; }
    public string cha_license_no { get; set; }
    public string user_job_no { get; set; }
    public string user_job_date { get; set; }
    public string invoice_sr_no { get; set; }
    public string actual_invoice_no { get; set; }
    public string invoice_date { get; set; }
    public string purchase_order_no { get; set; }
    public string purchase_order_date { get; set; }
    public string contract_no { get; set; }
    public string contract_date { get; set; }
    public string lc_no { get; set; }
    public string lc_date { get; set; }
    public string svb_reference_no { get; set; }
    public string svb_reference_date { get; set; }
    public string svb_load_assessable_value { get; set; }
    public string svb_load_on_duty { get; set; }
    public string svb_flag { get; set; }
    public string load_final_provisional_on_av { get; set; }
    public string load_final_provisional_on_duty { get; set; }
    public string custom_house_code_imposed_load { get; set; }
    public string nature_of_contract { get; set; }
    public string supplier_name { get; set; }
    public string supplier_address_1 { get; set; }
    public string supplier_address_2 { get; set; }
    public string supplier_address_3 { get; set; }
    public string supplier_country_name { get; set; }
    public string supplier_post_code { get; set; }
    public string seller_name { get; set; }
    public string seller_address_1 { get; set; }
    public string seller_address_2 { get; set; }
    public string seller_address_3 { get; set; }
    public string seller_country_name { get; set; }
    public string seller_post_code { get; set; }
    public string broker_name { get; set; }
    public string broker_address_1 { get; set; }
    public string broker_address_2 { get; set; }
    public string broker_address_3 { get; set; }
    public string broker_country_name { get; set; }
    public string broker_post_code { get; set; }
    public string invoice_value { get; set; }
    public string invoice_terms { get; set; }
    public string invoice_currency { get; set; }
    public string nature_of_discount { get; set; }
    public string discount_rate { get; set; }
    public string hss_load_rate { get; set; }
    public string hss_load_amount { get; set; }
    public string freight_currency { get; set; }
    public string freight_rate { get; set; }
    public string freight_value { get; set; }
    public string whether_freight_is_actual { get; set; }
    public string insurance_currency { get; set; }
    public string insurance_rate { get; set; }
    public string insurance_value { get; set; }
    public string misc_charges_currency { get; set; }
    public string misc_charges_rate { get; set; }
    public string misc_charges_value { get; set; }
    public string landing_rate { get; set; }
    public string loading_currency { get; set; }
    public string loading_rate { get; set; }
    public string loading_charges { get; set; }
    public string agency_commission_rate { get; set; }
    public string agency_commission_amount { get; set; }
    public string nature_of_transaction { get; set; }
    public string payment_terms { get; set; }
    public string conditions_with_sale_1 { get; set; }
    public string conditions_with_sale_2 { get; set; }
    public string conditions_with_sale_3 { get; set; }
    public string conditions_with_sale_4 { get; set; }
    public string conditions_with_sale_5 { get; set; }
    public string valuation_method_applicable { get; set; }
    public string other_relevant_information { get; set; }
}

public class BeIgmsInfo
{
    public string custom_house_code { get; set; }
    public string cha_license_no { get; set; }
    public string user_job_no { get; set; }
    public string user_job_date { get; set; }
    public string igm_no { get; set; }
    public string igm_date { get; set; }
    public string inward_date { get; set; }
    public string gateway_igm_no { get; set; }
    public string gateway_igm_date { get; set; }
    public string port_of_reporting { get; set; }
    public string mawb_bl_no { get; set; }
    public string mawb_bl_date { get; set; }
    public string hawb_hbl_no { get; set; }
    public string hawb_hbl_date { get; set; }
    public string total_no_of_packages { get; set; }
    public string gross_weight { get; set; }
    public string unit_quantity_code { get; set; }
    public string package_code { get; set; }
    public string marks_and_numbers_1 { get; set; }
    public string marks_and_numbers_2 { get; set; }
    public string marks_and_numbers_3 { get; set; }
}

public class BeItemsInfo
{
    public string quantity { get; set; }
    public string unit_price { get; set; }    
    public string ritc_code_itchs_code { get; set; }
    public string description_of_the_goods_1 { get; set; }

    //these new fields added on 18-04 as a part of 4th pahse requirenments.
    public string description_of_the_goods_2 { get; set; }
    public string unit_quantity_code { get; set; }    

    //these new fields added on 10-07 as a part of 5th pahse requirenments.
    public string item_category { get; set; }
    public string generic_description { get; set; }
    
    public string svb_loading_on { get; set; }
    public string svb_assesable_rate { get; set; }
    public string svb_duty_rate { get; set; }
    public string svb_assesable_status { get; set; }
    public string svb_duty_status { get; set; }
}

public class BeContainerInfo
{
    public string container_number { get; set; }
    public string container_size { get; set; }

    public string lcl_fcl { get; set; }
    public string excise_seal_no { get; set; }
}

//these new fields added on 10-07 as a part of 5th pahse requirenments.
public class BeItemSWInfoTypeInfo
{
    public string info_msr { get; set; }
    public string info_uqc { get; set; }
}

public class BeExchangeInfo
{
    public string rate { get; set; }
}
