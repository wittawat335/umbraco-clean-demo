using System.Net.Mail;

namespace umbraco_clean_demo.Domain.Entities.Kentico;

public class Attachment
{
public int AttachmentID{ get; set; }
public string AttachmentName{ get; set; }
public string AttachmentExtension { get; set; }
public int AttachmentSize{ get; set; }
public string AttachmentMimeType { get; set; }
public string AttachmentBinary { get; set; }
public int AttachmentImageWidth{ get; set; }
public int AttachmentImageHeight{ get; set; }
public int AttachmentDocumentID{ get; set; }
//public string AttachmentGUID{ get; set; }
public int AttachmentSiteID{ get; set; }
public DateTime AttachmentLastModified{ get; set; }
//public  AttachmentIsUnsorted{ get; set; }
public int AttachmentOrder{ get; set; }
//public  AttachmentGroupGUID{ get; set; }
//public  AttachmentFormGUID{ get; set; }
public string AttachmentHash { get; set; }
public string AttachmentTitle{ get; set; }
public string AttachmentDescription{ get; set; }
public string AttachmentCustomData{ get; set; }
public string AttachmentSearchContent{ get; set; }
public string AttachmentVariantDefinitionIdentifier { get; set; }
public int AttachmentVariantParentID{ get; set; }
}

