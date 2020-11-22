using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.OPPO.Mo.Thirdparty.Megvii.Request
{
    public class AddPhotoRequest
    {
        [JsonProperty("photo")]
        public byte[] Photo { get; set; }
        [JsonProperty("subject_id")]
        public string SubjectId { get; set; }
        [JsonProperty("old_photo_id")]
        public string OldPhotoId { get; set; }
    }
}
