using System;

namespace SharedLibraryParseXamarinForms.Models
{
	public class ParseDate : Parse.ParseObject
	{
		public string DateStr { get; set; }

		public ParseDate (Parse.ParseObject parseObject)
			: base ("Date") {

			ACL = parseObject.ACL;
			this["CreatedAt"] = parseObject.CreatedAt;
			this["IsDataAvailable"] = parseObject.IsDataAvailable;
			this["IsDirty"] = parseObject.IsDirty;
			this["IsNew"] = parseObject.IsNew;
			ObjectId = parseObject.ObjectId;
			this["UpdatedAt"] = parseObject.UpdatedAt;

			DateStr = parseObject["DateStr"].ToString ();
		}
	}
}