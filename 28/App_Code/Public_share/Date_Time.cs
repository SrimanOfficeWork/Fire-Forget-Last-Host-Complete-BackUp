using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Date_Time
/// </summary>
public class Date_Time
{
	public string Today_Date()
	{
        DateTime dat = System.DateTime.Now;
        string datestring = string.Format("{0:dd/MM/yyyy}", dat);
        return datestring;
	}
    public string Today_Date_Mon()
    {
        DateTime dat = System.DateTime.Now;
        string datestring = string.Format("{0:dd-MMM-yyyy}", dat);
        return datestring;
    }
   
    public string Split(string split_tag, string str)
    {
        
        if (str.Contains(split_tag))
        {
            string[] s1 = str.Split(new string[] { split_tag }, StringSplitOptions.None);
            
            if (split_tag != "")
            {
                str = s1[0].ToString();
            }
            else
            {
                str = "";
            }
        }
        return str;
    }
    public string Split_main(string split_tag, string str)
    {
        string[] s1 = str.Split(new string[] { split_tag }, StringSplitOptions.None);
        string s="";
        if (split_tag != "")
        {
            s = s1[1].ToString();
        }
        else
        {
            s = "";
        }
        return s;
    }
    public string Get_Exchange_PerUnit(string Currency)
    {
        if (Currency == "JPY" || Currency == "KRW")
            Currency = "100";
        else
            Currency = "1";
        return Currency;
    }
    public string Get_Nullval(string str)
    {
       // if (str == "0" || str == "0.00" || str == " " || str.Substring(1, 1) == "." || str == ".0" || str == "0.0000")
        if (str != "")
        {
            if (str == "0" || str == "0.0" || str == "0.00" || str == " " || str.Substring(0, 1) == "." || str == "0.0000")
                str = "";
        }
        else
        {
            if (str == "0" || str == "0.0" || str == "0.00" || str == " " || str == ".0" || str == "0.0000")
                str = "";
        }
        return str;
    }

    public string Get_Nullval_New(string str)
    {
        // if (str == "0" || str == "0.00" || str == " " || str.Substring(1, 1) == "." || str == ".0" || str == "0.0000")
        if (str != "")
        {
            if (str == "0" || str == "0.00" || str == " " || str == "0.0000")
                str = "";
        }
        else
        {
            if (str == "0" || str == "0.00" || str == " " || str == ".0" || str == "0.0000")
                str = "";
        }
        return str;
    }

    public string Trim(string str)
    {
        if (str.Contains("."))
        {
            string[] s1 = str.Split(new string[] { "." }, StringSplitOptions.None);
            string num="123456789";
            if (num.Contains(s1[1].ToString()))
            {

            }
            else
            {
                str.Trim().Replace(".00", "").Replace(".0000", "");

            }
            
        }
        //return str.Trim().Replace("amp;", "").Replace("`", "").Replace("'", "").Replace("&nbsp;", "").Replace("&nbsp;", "").Replace(".00", "").Replace(".0000", "");
        return str.Trim().Replace("amp;", "").Replace("`", "").Replace("'", "").Replace("&nbsp;", "").Replace("&nbsp;", "");
    }
    public string Trim_Single_Quote(string str)
    {
        if (str.Contains("."))
        {
            string[] s1 = str.Split(new string[] { "." }, StringSplitOptions.None);
            string num = "123456789";
            if (num.Contains(s1[1].ToString()))
            {

            }
            else
            {
                str.Trim().Replace(".00", "").Replace(".0000", "");

            }

        }
        //return str.Trim().Replace("amp;", "").Replace("`", "").Replace("'", "").Replace("&nbsp;", "").Replace("&nbsp;", "").Replace(".00", "").Replace(".0000", ""); .Replace("'", "")
        return str.Trim().Replace("amp;", "").Replace("`", "").Replace("&nbsp;", "").Replace("&nbsp;", "");
    }
    public string amt_Trim(string str)
    {
        //return str.Trim().Replace("`", "").Replace("'", "");
        return str.Trim().Replace("amp;", "").Replace("`", "").Replace("'", "").Replace("&nbsp;", "").Replace("&nbsp;", "");
    }
    public string Num_Trim(string str)
    {
        
        //return str.Trim().Replace("amp;", "").Replace("`", "").Replace("'", "").Replace("&nbsp;", "").Replace("&nbsp;", "").Replace(".0000", "");
        return str.Trim().Replace("amp;", "").Replace("`", "").Replace("'", "").Replace("&nbsp;", "").Replace("&nbsp;", "");
    }
    public string Replace(string str)
    {
        //return str.Trim().Replace("`", "").Replace("'", "");
        return str.Replace("&amp;", "&").Replace("&quot;", @"""").Replace("&nbsp;", "").Replace("&#39;", "'").Replace("", "").Replace(";", ""); 

    }
}