using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Dto
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore]//bunu json'a dönüştürürken ignore et
        public int StatusCode { get; set; }//hata durum kodu orn:200
        public List<String> Errors { get; set; }//hataları tutacak.
        //static factory methods
        //factory design pattern'den geliyor.
        //nesne üretme olayı bu sınıf içerisinden gerçekleşiyor.
        public static CustomResponseDto<T> Success(int statusCode, T data)
        {
            return new CustomResponseDto<T> { Data = data,StatusCode=statusCode };
        }
        public static CustomResponseDto<T> Success(int statusCode)
        {
            return new CustomResponseDto<T> {StatusCode = statusCode};
        }
        //Birden fazla hata gelebileceği için errors'u List<> olarak alıyorum
        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
        {
            return new CustomResponseDto<T> { StatusCode = statusCode,Errors = errors };
        }
        //Tekli hata
        public static CustomResponseDto<T> Fail(int statusCode, string error)
        {
            return new CustomResponseDto<T>
            {
                StatusCode = statusCode,
                Errors = new List<string> { error }
            };
        }
    }
}
