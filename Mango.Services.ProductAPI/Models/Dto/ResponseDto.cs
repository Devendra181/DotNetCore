﻿namespace Mango.Services.ProductAPI.Models.Dto
{
    public class ResponseDto
    {
        public object? Result { get; set; }

        public bool IsSucces { get; set; } = true;
        public string Mesages { get; set; } = "";
    }
}
