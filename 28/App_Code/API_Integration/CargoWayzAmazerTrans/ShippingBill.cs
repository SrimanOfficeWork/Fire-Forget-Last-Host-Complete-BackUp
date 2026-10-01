using System.Collections.Generic;

/// <summary>
/// Description for ShippingBill
/// </summary>


public class ShippingBill
{
    public string doc_type { get; set; }
    public Header header { get; set; }
    public GeneralInfo general_info { get; set; }
    public List<InvoiceInfo> invoice_info { get; set; }
    public List<ItemInfo> item_info { get; set; }
    public ExchangeInfo exchange_info { get; set; }
    public DbkInfo dbkInfo { get; set; }
    public LicenseInfo licenseInfo { get; set; }
    public List<ContainerInfo> container_info { get; set; }

    public ShippingBill()
    {
        invoice_info = new List<InvoiceInfo>();
        item_info = new List<ItemInfo>();
        container_info = new List<ContainerInfo>();
    }
}

public class Header
{
    public string company_id { get; set; }
    public string record_type { get; set; }
    public string sender_id_type { get; set; }
    public string sender_id { get; set; }
    public string receiver_id_type { get; set; }
    public string receiver_id { get; set; }
    public string version { get; set; }
    public string file_type { get; set; }
    public string blank_1 { get; set; }
    public string message_id { get; set; }
    public string sequence_no { get; set; }
    public string date { get; set; }
    public string time { get; set; }
}

public class GeneralInfo
{
    public string custom_house_code { get; set; }
    public string cha_license_no { get; set; }
    public string user_job_no { get; set; }
    public string user_job_date { get; set; }
    public string sb_no { get; set; }
    public string sb_date { get; set; }
    public string icegate_user_id { get; set; }
    public string importer_exporter_code { get; set; }
    public string branch_sr_no_of_exporter { get; set; }
    public string imp_exp_name { get; set; }
    public string imp_exp_address { get; set; }
    public string imp_exp_address_2 { get; set; }
    public string imp_exp_city { get; set; }
    public string imp_exp_state { get; set; }
    public string imp_exp_pin { get; set; }
    public string type_of_exporter { get; set; }
    public string exporter_class { get; set; }
    public string state_of_origin_exporter { get; set; }
    public string authorized_dealer_code { get; set; }
    public string epz_code { get; set; }
    public string consignee_name { get; set; }
    public string consignee_address_1 { get; set; }
    public string consignee_address_2 { get; set; }
    public string consignee_address_3 { get; set; }
    public string consignee_address_4 { get; set; }
    public string consignee_country { get; set; }
    public string category_of_nfei_sb { get; set; }
    public string rbi_waiver_no { get; set; }
    public string rbi_waiver_date { get; set; }
    public string port_of_loading { get; set; }
    public string port_of_discharge { get; set; }
    public string country_of_discharge { get; set; }
    public string port_of_final_destination { get; set; }
    public string country_of_final_destination { get; set; }
    public string seal_type { get; set; }
    public string nature_of_cargo { get; set; }
    public string gross_weight { get; set; }
    public string net_weight { get; set; }
    public string unit_of_measurement { get; set; }
    public string total_no_of_packages { get; set; }
    public string marks_and_numbers { get; set; }
    public string no_of_loose_packets { get; set; }
    public string no_of_containers { get; set; }
    public string mawb_no { get; set; }
    public string hawb_no { get; set; }
    public string gstn_type { get; set; }
    public string gstn_id { get; set; }
}

public class InvoiceInfo
{
    public string custom_house_code { get; set; }
    public string cha_license_no { get; set; }
    public string user_job_no { get; set; }
    public string user_job_date { get; set; }
    public string invoice_sr_no { get; set; }
    public string actual_invoice_no { get; set; }
    public string invoice_date { get; set; }
    public string invoice_currency { get; set; }
    public string nature_of_contract { get; set; }
    public string buyer_name { get; set; }
    public string buyer_address_1 { get; set; }
    public string buyer_address_2 { get; set; }
    public string buyer_address_3 { get; set; }
    public string buyer_address_4 { get; set; }
    public string freight_currency { get; set; }
    public string freight_amount { get; set; }
    public string insurance_rate { get; set; }
    public string insurance_currency { get; set; }
    public string insurance_amount { get; set; }
    public string commission_rate { get; set; }
    public string commission_currency { get; set; }
    public string commission_amount { get; set; }
    public string discount_on_fob { get; set; }
    public string discount_currency { get; set; }
    public string discount_amount { get; set; }
    public string other_deductions { get; set; }
    public string other_deductions_currency { get; set; }
    public string other_deductions_amount { get; set; }
    public string add_freight { get; set; }
    public string packing_charges { get; set; }
    public string exporter_contract_no { get; set; }
    public string nature_of_payment { get; set; }
    public string period_of_payment_in_days { get; set; }
    public string gross_weight { get; set; }
    public string net_weight { get; set; }
    public string invoice_value_fcy { get; set; }
    public string invoice_value_inr { get; set; }
    public string ritc { get; set; }
    public string fob_value { get; set; }
    public string dbk_code { get; set; }
    public string dbk_amount { get; set; }

    public string exchange_rate { get; set; }
    public string state_of_origin { get; set; }
}

public class ItemInfo
{
    public string custom_house_code { get; set; }
    public string user_job_no { get; set; }
    public string user_job_date { get; set; }
    public string invoice_sr_no { get; set; }
    public string item_sr_no { get; set; }
    public string cha_license_no { get; set; }
    public string sb_no { get; set; }
    public string sb_date { get; set; }
    public string scheme_code { get; set; }
    public string ritc_code_itchs_code { get; set; }
    public string description_of_the_goods_1 { get; set; }
    public string description_of_the_goods_2 { get; set; }
    public string description_of_the_goods_3 { get; set; }
    public string unit_of_measurement { get; set; }
    public string quantity { get; set; }
    public string unit_price { get; set; }
    public string unit_of_rate { get; set; }
    public string no_of_units_per { get; set; }
    public string present_market_value_lcy { get; set; }
    public string job_work_notification_no { get; set; }
    public string third_party { get; set; }
    public string reward_item { get; set; }
}

public class ExchangeInfo
{
    public string custom_house_code { get; set; }
    public string user_job_no { get; set; }
    public string user_job_date { get; set; }
    public string item_sr_no { get; set; }
    public string dbk_schedule_no { get; set; }
    public string cha_license_no { get; set; }
    public string invoice_sr_no { get; set; }
    public string sb_no { get; set; }
    public string sb_date { get; set; }
    public string drawback_quantity { get; set; }
}

public class DbkInfo
{
    public string custom_house_code { get; set; }
    public string user_job_no { get; set; }
    public string user_job_date { get; set; }
    public string item_sr_no { get; set; }
    public string dbk_schedule_no { get; set; }
    public string cha_license_no { get; set; }
    public string invoice_sr_no { get; set; }
    public string sb_no { get; set; }
    public string sb_date { get; set; }
    public string drawback_quantity { get; set; }
}

public class LicenseInfo
{
    public string custom_house_code { get; set; }
    public string cha_license_no { get; set; }
    public string user_job_no { get; set; }
    public string user_job_date { get; set; }
    public string invoice_sr_no { get; set; }
    public string item_sr_no { get; set; }
    public string registration_no { get; set; }
    public string srno { get; set; }
    public string sb_no { get; set; }
    public string sb_date { get; set; }
    public string registration_date { get; set; }
    public string item_sr_no_in_part_e { get; set; }
    public string item_sr_no_in_part_c { get; set; }
    public string quantity { get; set; }
    public string export_quantity { get; set; }
    public string whether_indigenous_or_imported { get; set; }
}

public class ContainerInfo
{
    public string container_number { get; set; }
    public string container_size { get; set; }

    public string lcl_fcl { get; set; }
    public string excise_seal_no { get; set; }
}
