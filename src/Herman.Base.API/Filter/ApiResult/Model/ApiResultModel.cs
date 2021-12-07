using System;
using System.Net;
using System.Runtime.Serialization;
using Herman.Base.API.Filter.ApiResult.Model.Generic;

namespace Herman.Base.API.Filter.ApiResult.Model
{
    /// <summary>
    /// 标准返回
    /// </summary>
    [DataContract]
    public class ApiResultModel<TData>
    {
        /// <summary>
        /// 状态码说明
        /// </summary>
        [DataMember(Name = "status")]
        public HttpStatusCode Status { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        [DataMember(Name = "statusCode")]
        public int StatusCode { get; set; }

        public static implicit operator ApiResultModel<TData>(ApiResultModel a)
        {
            if (a.Data == null)
            {
                return new ApiResultModel<TData>()
                {
                    Data = default(TData),
                    Message = a.Message,
                    Status = a.Status,
                    StatusCode = a.StatusCode
                };
            }
            if (a.Data is TData)
            {
                return new ApiResultModel<TData>()
                {
                    Data = (TData)a.Data,
                    Message = a.Message,
                    Status = a.Status,
                    StatusCode = a.StatusCode
                };
            }
            throw new NotImplementedException($"convert from ApiResultModel to ApiResultModel[{typeof(TData).FullName}] failed! ");
        }

        public static implicit operator ApiResultModel(ApiResultModel<TData> a)
        {
            return new ApiResultModel()
            {
                Data = a.Data,
                Message = a.Message,
                Status = a.Status,
                StatusCode = a.StatusCode
            };
        }

        /// <summary>
        /// 返回消息
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "data")]
        public TData Data { get; set; }
    }
}



