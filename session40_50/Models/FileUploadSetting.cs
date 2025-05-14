﻿namespace session40_50.Models
{
    public class FileUploadSettings
    {
        public long MaxFileSize { get; set; }
        public string[] AllowExtensions { get; set; }
        public string UploadPath { get; set; }
    }

    public class UploadResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string FilePath { get; set; }
    }

}
