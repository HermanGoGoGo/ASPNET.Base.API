using System;
using System.Net;
using Abp.AspNetCore.Mvc.Controllers;
using AI5yue.Base.API.Filter.ApiResult.Model;
using AI5yue.Base.API.Filter.ApiResult.Model.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AI5yue.Base.API.Controllers
{
    public abstract class BaseControllerBase: AbpController
    {
        private readonly ILogger _logger;

        protected BaseControllerBase(ILogger logger)
        {
            _logger = logger;
            LocalizationSourceName = BaseConsts.LocalizationSourceName;
        }


        protected string LogUserName
        {
            get
            {
                // if (!string.IsNullOrEmpty(_userName) && _accessTokenExpires.HasValue && _accessTokenExpires.Value > DateTime.UtcNow)
                //     return _userName;
                var userName = Request.HttpContext.User?.Identity?.Name;

                return userName;
            }
        }

        /// <summary>
        /// �Զ��巵��
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [NonAction]
        public ApiResultModel<T> CustomResult<T>(string message, int status)
        {
            var result = new ApiResultModel<T>();
            if (status > -1)
            {
                result.Status = (HttpStatusCode)Enum.ToObject(typeof(HttpStatusCode), status);
                result.StatusCode = status;
            }

            if (!string.IsNullOrEmpty(message))
            {
                result.Message = message;
            }

            return result;
        }

        /// <summary>
        /// �ɹ�����
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [NonAction]
        public ApiResultModel<T> SuccessResult<T>(string message = null, int status = 200)
        {
            return CustomResult<T>(message, status);
        }

        // /// <summary>
        // /// ʧ�ܷ���
        // /// </summary>
        // /// <param name="message"></param>
        // /// <param name="status"></param>
        // /// <returns></returns>
        // public ApiResultModel<T> BadResult<T>(string message = "Http Request Fail", int status = 400)
        // {
        //     return CustomResult<T>(message, status);
        // }

        /// <summary>
        /// ʧ�ܷ���
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [NonAction]
        public ApiResultModel<T> BadResult<T>(string message = "Http Request Fail", int status = 400)
        {
            _logger.LogError($"��ǰϵͳ�û���{LogUserName} {Request.Path + Request.QueryString} --  {message}");
            return CustomResult<T>(message, status);
        }

        /// <summary>
        /// ������У�飩ʧ�ܷ���
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        /// 
        [NonAction]
        public ApiResultModel<T> ValidationErrorResult<T>(string message = "Validation Error", int status = 400)
        {
            return CustomResult<T>(message, status);
        }

        ///// <summary>
        ///// ���캯��
        ///// </summary>
        //public ApiResultHelper()
        //{
        //    if (result == null)
        //    {
        //        result = new ApiResultModel<T>();
        //    }
        //}

        /// <summary>
        /// �Զ��巵��
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 
        [NonAction]
        public ApiResultModel<T> CustomResult<T>(string message, int status, T data = default)
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
        /// �Զ��巵��
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        /// 
        [NonAction]
        public ApiResultModel CustomResult(string message, int status, Object data = default)
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
        /// �ɹ�����
        /// </summary>
        /// <param name="data"></param>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [NonAction]
        public ApiResultModel<T> SuccessResult<T>(T data = default, string message = null, int status = 200)
        {
            return CustomResult(message, status, data);
        }

        /// <summary>
        /// ʧ�ܷ���
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [NonAction]
        public ApiResultModel BadResult(string message = "Http Request Fail", int status = 400)
        {
            _logger.LogError($"��ǰϵͳ�û���{LogUserName} {Request.Path + Request.QueryString} --  {message}");
            return CustomResult(message, status, default(object));
        }

        /// <summary>
        /// ������У�飩ʧ�ܷ���
        /// </summary>
        /// <param name="message"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [NonAction]
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
        [NonAction]
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
        [NonAction]
        public ApiResultModel NotFound(string message = "Resource not found", int status = 404)
        {
            return CustomResult(message, status, default(Object));
        }
    }
}

