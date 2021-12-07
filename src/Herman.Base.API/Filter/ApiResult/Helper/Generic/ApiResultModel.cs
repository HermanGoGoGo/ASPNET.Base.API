using System;
using System.Net;
using Herman.Base.API.Filter.ApiResult.Model;
using Herman.Base.API.Filter.ApiResult.Model.Generic;

namespace Herman.Base.API.Filter.ApiResult.Helper.Generic
{
    /// <summary>
    /// api统一返回帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResultHelper
    {
        

        ///// <summary>
        ///// 构造函数
        ///// </summary>
        //public ApiResultHelper()
        //{
        //    if (result == null)
        //    {
        //        result = new ApiResultModel<T>();
        //    }
        //}

        /// <summary>
        /// 自定义返回
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ApiResultModel<T> CustomResult<T>(string message, int status, T data = default)
        {
            var result = new ApiResultModel<T>() { };
            if (status > -1)
            {
                result.StatusCode = status;
                result.Status = (HttpStatusCode)Enum.ToObject(typeof(HttpStatusCode), status);
            }

            if (!string.IsNullOrEmpty(message))
            {
                result.Message = message;
            }

            if (data != null)
            {
                result.Data = data;
            }

            return result;
        }
        /// <summary>
        /// 自定义返回
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static ApiResultModel CustomResult(string message, int status, Object data = default)
        {
            var result = new ApiResultModel() { };
            if (status > -1)
            {
                result.StatusCode = status;
                result.Status = (HttpStatusCode)Enum.ToObject(typeof(HttpStatusCode), status);
            }

            if (!string.IsNullOrEmpty(message))
            {
                result.Message = message;
            }

            if (data != null)
            {
                result.Data = data;
            }

            return result;
        }

        /// <summary>
        /// 成功返回
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static ApiResultModel<T> SuccessResult<T>(T data = default, string message = null, int status = 200)
        {
            return CustomResult(message, status, data);
        }

        /// <summary>
        /// 失败返回
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static ApiResultModel<T> BadResult<T>(string message = "Http Request Fail", int status = 400)
        {
            return CustomResult(message, status, default(T));
        }

        /// <summary>
        /// 失败返回
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public static ApiResultModel BadResult(string message = "Http Request Fail", int status = 400)
        {
            return CustomResult(message, status, default(object));
        }


        /// <summary>
        /// 参数（校验）失败返回
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ApiResultModel<T> ValidationErrorResult<T>(string message = "Validation Error", int status = 400)
        {
            return CustomResult(message, status, default(T));
        }

        /// <summary>
        /// 参数（校验）失败返回
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ApiResultModel ValidationErrorResult(string message = "Validation Error", int status = 400)
        {
            return CustomResult(message, status, default(Object));
        }

        /// <summary>
        /// 404 not found
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ApiResultModel<T> NotFound<T>(string message = "Resource not found", int status = 404)
        {
            return CustomResult(message, status, default(T));
        }

        /// <summary>
        /// 404 not found
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public ApiResultModel NotFound(string message = "Resource not found", int status = 404)
        {
            return CustomResult(message, status, default(Object));
        }
    }
}



