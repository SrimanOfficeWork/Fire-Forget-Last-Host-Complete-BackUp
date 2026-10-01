using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BussinessObject;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

public class billing_Mis
{
    DataSet ds = new DataSet();

    private const string TotalRowLabel = "Total";
    private const string LocationColumn = "Label";
    public DataSet GetMonthWiseReport(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (!string.IsNullOrEmpty(objUserBL.A1))
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + "/" + arr[0] + "/" + arr[2];
            }

            if (!string.IsNullOrEmpty(objUserBL.A2))
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + "/" + arr2[0] + "/" + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@FromDate", objUserBL.A1);
            param[1] = new SqlParameter("@ToDate", objUserBL.A2);
            param[2] = new SqlParameter("@ExcludeTax", objUserBL.A3);
            param[3] = new SqlParameter("@BRANCH", objUserBL.A4);
            param[4] = new SqlParameter("@Cus_Name", objUserBL.A4);
            param[5] = new SqlParameter("@FLAG", objUserBL.A5);

         
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[14] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_BILLING_MIS_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }


 public DataSet Purchase_GetMonthWiseReport(Global_variables objUserBL)
    {
        try
        {
            string[] arr = new string[] { };
            string[] arr2 = new string[] { };

            if (!string.IsNullOrEmpty(objUserBL.A1))
            {
                arr = objUserBL.A1.Split('/');
                objUserBL.A1 = arr[1] + "/" + arr[0] + "/" + arr[2];
            }

            if (!string.IsNullOrEmpty(objUserBL.A2))
            {
                arr2 = objUserBL.A2.Split('/');
                objUserBL.A2 = arr2[1] + "/" + arr2[0] + "/" + arr2[2];
            }

            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@FromDate", objUserBL.A1);
            param[1] = new SqlParameter("@ToDate", objUserBL.A2);
            param[2] = new SqlParameter("@ExcludeTax", objUserBL.A3);
            param[3] = new SqlParameter("@BRANCH", objUserBL.A4);
            param[4] = new SqlParameter("@Cus_Name", objUserBL.A4);
            param[5] = new SqlParameter("@FLAG", objUserBL.A5);

         
            param[12] = new SqlParameter("@Branch_Common", Connection.Get_Company_Type());
            param[13] = new SqlParameter("@Working_Period", Connection.WorkingPeriod());
            param[14] = new SqlParameter("@COMPANY_LICENSE", Connection.Company_License());

            param[15] = new SqlParameter("@ErrorMsg", SqlDbType.NVarChar, 1000);
            param[15].Direction = ParameterDirection.Output;

            ds = Connection.Get_Dataset("ACC_GST_PURCHASE_MIS_SEARCH_SELECT", param);
        }
        catch (Exception ex)
        {
            Connection.Error_Msg(ex.Message);
        }

        return ds;
    }
    public DataTable GetMonthWisePivotReport(Global_variables objUserBL)
    {
        DataSet ds = GetMonthWiseReport(objUserBL);
        DataTable longFormat = ds.Tables[0];

        DataTable pivot = new DataTable();
        pivot.Columns.Add("Label", typeof(string));

        if (longFormat.Rows.Count == 0)
        {
            pivot.Columns.Add(TotalRowLabel, typeof(decimal));
            return pivot;
        }

       
        var monthColumns = longFormat.AsEnumerable()
            .Select(r => new
            {
                Year = Convert.ToInt32(r["Year"]),
                MonthNo = Convert.ToInt32(r["MonthNo"]),
                Label = Convert.ToString(r["MonthLabel"])
            })
            .Distinct()
            .OrderBy(x => x.Year)
            .ThenBy(x => x.MonthNo)
            .ToList();

        foreach (var m in monthColumns)
        {
            pivot.Columns.Add(m.Label, typeof(decimal));
        }
        pivot.Columns.Add(TotalRowLabel, typeof(decimal));

       
        var locations = longFormat.AsEnumerable()
            .Select(r => Convert.ToString(r["Label"]))
            .Distinct()
            .ToList();

       
        var lookup = longFormat.AsEnumerable().ToDictionary(
            r => Tuple.Create(
                Convert.ToString(r["Label"]),
                Convert.ToInt32(r["Year"]),
                Convert.ToInt32(r["MonthNo"])),
            r => Convert.ToDecimal(r["TotalAmount"]));

        decimal[] columnTotals = new decimal[monthColumns.Count];
        decimal grandTotal = 0m;

        foreach (string location in locations)
        {
            DataRow row = pivot.NewRow();
            row["Label"] = location;
            decimal rowTotal = 0m;

            for (int i = 0; i < monthColumns.Count; i++)
            {
                var m = monthColumns[i];
                decimal amt;
                lookup.TryGetValue(Tuple.Create(location, m.Year, m.MonthNo), out amt);

                row[m.Label] = amt;
                rowTotal += amt;
                columnTotals[i] += amt;
            }

            row[TotalRowLabel] = rowTotal;
            grandTotal += rowTotal;
            pivot.Rows.Add(row);
        }

        DataRow totalRow = pivot.NewRow();
        totalRow["Label"] = TotalRowLabel;
        for (int i = 0; i < monthColumns.Count; i++)
        {
            totalRow[monthColumns[i].Label] = columnTotals[i];
        }
        totalRow[TotalRowLabel] = grandTotal;
        pivot.Rows.Add(totalRow);

        return pivot;
    }
    public DataTable Purchase_GetMonthWisePivotReport(Global_variables objUserBL)
    {
        DataSet ds = Purchase_GetMonthWiseReport(objUserBL);
        DataTable longFormat = ds.Tables[0];

        DataTable pivot = new DataTable();
        pivot.Columns.Add("Label", typeof(string));

        if (longFormat.Rows.Count == 0)
        {
            pivot.Columns.Add(TotalRowLabel, typeof(decimal));
            return pivot;
        }

       
        var monthColumns = longFormat.AsEnumerable()
            .Select(r => new
            {
                Year = Convert.ToInt32(r["Year"]),
                MonthNo = Convert.ToInt32(r["MonthNo"]),
                Label = Convert.ToString(r["MonthLabel"])
            })
            .Distinct()
            .OrderBy(x => x.Year)
            .ThenBy(x => x.MonthNo)
            .ToList();

        foreach (var m in monthColumns)
        {
            pivot.Columns.Add(m.Label, typeof(decimal));
        }
        pivot.Columns.Add(TotalRowLabel, typeof(decimal));

      
        var locations = longFormat.AsEnumerable()
            .Select(r => Convert.ToString(r["Label"]))
            .Distinct()
            .ToList();

    
        var lookup = longFormat.AsEnumerable().ToDictionary(
            r => Tuple.Create(
                Convert.ToString(r["Label"]),
                Convert.ToInt32(r["Year"]),
                Convert.ToInt32(r["MonthNo"])),
            r => Convert.ToDecimal(r["TotalAmount"]));

        decimal[] columnTotals = new decimal[monthColumns.Count];
        decimal grandTotal = 0m;

        foreach (string location in locations)
        {
            DataRow row = pivot.NewRow();
            row["Label"] = location;
            decimal rowTotal = 0m;

            for (int i = 0; i < monthColumns.Count; i++)
            {
                var m = monthColumns[i];
                decimal amt;
                lookup.TryGetValue(Tuple.Create(location, m.Year, m.MonthNo), out amt);

                row[m.Label] = amt;
                rowTotal += amt;
                columnTotals[i] += amt;
            }

            row[TotalRowLabel] = rowTotal;
            grandTotal += rowTotal;
            pivot.Rows.Add(row);
        }

        DataRow totalRow = pivot.NewRow();
        totalRow["Label"] = TotalRowLabel;
        for (int i = 0; i < monthColumns.Count; i++)
        {
            totalRow[monthColumns[i].Label] = columnTotals[i];
        }
        totalRow[TotalRowLabel] = grandTotal;
        pivot.Rows.Add(totalRow);

        return pivot;
    }
    //public DataTable GetMonthWisePivotReport(Global_variables objUserBL)
    //{
    //    DataSet ds = GetMonthWiseReport(objUserBL);
    //    DataTable longFormat = ds.Tables[0];

    //    DataTable pivot = new DataTable();

    //    if (longFormat.Rows.Count == 0)
    //    {
    //        pivot.Columns.Add("Total", typeof(decimal));
    //        return pivot;
    //    }

    //    var monthColumns = longFormat.AsEnumerable()
    //        .Select(r => new
    //        {
    //            Year = Convert.ToInt32(r["Year"]),
    //            MonthNo = Convert.ToInt32(r["MonthNo"]),
    //            Label = CultureInfo.InvariantCulture.DateTimeFormat
    //                .GetAbbreviatedMonthName(Convert.ToInt32(r["MonthNo"]))
    //                + " " + Convert.ToInt32(r["Year"])
    //        })
    //        .Distinct()
    //        .OrderBy(x => x.Year)
    //        .ThenBy(x => x.MonthNo)
    //        .ToList();

    //    // Create month columns
    //    foreach (var m in monthColumns)
    //    {
    //        pivot.Columns.Add(m.Label, typeof(decimal));
    //    }

    //    pivot.Columns.Add("Total", typeof(decimal));

    //    // Only ONE row (Total row)
    //    DataRow totalRow = pivot.NewRow();

    //    decimal grandTotal = 0;

    //    for (int i = 0; i < monthColumns.Count; i++)
    //    {
    //        var month = monthColumns[i];

    //        decimal monthTotal = longFormat.AsEnumerable()
    //            .Where(r =>
    //                Convert.ToInt32(r["Year"]) == month.Year &&
    //                Convert.ToInt32(r["MonthNo"]) == month.MonthNo)
    //            .Sum(r => Convert.ToDecimal(r["TotalAmount"]));

    //        totalRow[month.Label] = monthTotal;
    //        grandTotal += monthTotal;
    //    }

    //    totalRow["Total"] = grandTotal;

    //    pivot.Rows.Add(totalRow);

    //    return pivot;
    //}
}