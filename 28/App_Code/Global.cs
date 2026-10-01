using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for Class1
/// </summary>
public static class Global
{
    /// <summary>
    /// Global variable storing important stuff.
    /// </summary>
    static string _importantData;

    /// <summary>
    /// Get or set the static important data.
    /// </summary>
    public static string ImportantData
    {
        get
        {
            return _importantData;
        }
        set
        {
            _importantData = value;
        }
    }
}