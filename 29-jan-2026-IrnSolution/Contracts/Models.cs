namespace Contracts
{
    public record UploadRequest
    {
        public string CorrelationId { get; init; }
        public string? FolderPath { get; init; }
        public List<FileDescriptor> Files { get; init; } = new();
        public DateTime RequestedUtc { get; init; } = DateTime.UtcNow;
        public string? IcegateUser { get; init; }
        public string? IcegatePassword { get; init; }
        public string? CompanyId { get; init; }
        public string? BranchCode { get; init; }
        public string? Client { get; init; }
        public string? Working_Period { get; set; }
        public string? User_id { get; set; }
        public string? JobNo { get; init; }
        public string? serverIP { get; init; }
        public string? JobType { get; init; }
        public string? Icegateerror { get; set; }
        public string? MailType { get; set; }
        public string? Mailid { get; set; }
        public string? password { get; set; }
        public string? Mobno { get; set; }
        public string? Mailhost { get; set; }
        public string? Mailssl { get; set; }
        public string? Mailport { get; set; }

        public string? TransId { get; set; }

        public string? MailTenentid { get; set; }
        public string? MailClientid { get; set; }
        public string? MailScreenid { get; set; }



    }
    public record UploadResult
    {
        public string CorrelationId { get; init; } = string.Empty;
        public bool Success { get; init; }
        public string? Error { get; init; }
        public List<FileUploadOutcome> Outcomes { get; init; } = new();
    }
    public record FileDescriptor
    {
        public string? Jobno { get; init; }
        public string? Jobtype { get; init; }
        public string? Inv_sl { get; init; }
        public string? itm_sl { get; init; }
        public string FileName { get; init; } = string.Empty;
        public string DocumentType { get; init; } = string.Empty;
        public string? Level { get; init; }
        public string? Iss_party { get; init; }
        public string? POI { get; init; }
        public string? DOI { get; init; }
        public string? Ben_party { get; init; }
        public string? IRN_STATUS { get; init; }
        public string? GuidId { get; init; }
        public string? FileContent { get; set; }
       
        public string? EXPORTER_ADDRESS1 { get; set; }
        public string? EXPORTER_ADDRESS2 { get; set; }
        public string? EXPORTER_ADDRESS3 { get; set; }
        public string? EXPORTER_ADDRESS5 { get; set; }
        public string? CONSIGNEE_ADD1 { get; set; }
        public string? CONSIGNEE_ADD2 { get; set; }
        public string? CONSIGNEE_ADD3 { get; set; }
        public string? CONSIGNEE_ADD5 { get; set; }

    }
    public record FileUploadOutcome
    {
        public string FileName { get; init; } = string.Empty;
        public string DocumentType { get; init; } = string.Empty;
        public bool Success { get; init; }
        public string? Message { get; init; }
        public string? IRNNo { get; init; }
        public string? DRNNo { get; init; }
        public string? IRN_STATUS { get; init; }
        public string? Doc_Type { get; init; }
        public string? ReturnedId { get; init; }
    }
}