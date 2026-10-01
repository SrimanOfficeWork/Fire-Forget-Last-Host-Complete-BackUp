using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for EmailHistory
/// </summary>
public class EmailHistory
{
    public int Id { get; set; }
    public string Body { get; set; }
    public string Subject { get; set; }
    public DateTime DateTime { get; set; }
    public bool IsNew { get; set; }
    public string FromEmail { get; set; }
    public string FromName { get; set; }
    public string ToEmail { get; set; }
    public string ToName { get; set; }
    public string MessageId { get; set; }
    //public List<Attachment> Attachments { get; set; }
	public EmailHistory()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}