using Microsoft.AspNetCore.Authorization;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Services.Dtos.User.Create;
using Services.Services.Abstraction;
using Services.Services.Implementation;
using Services.Dtos.Email.Create;
using Services.Dtos.Email.Update;
using Services.Models;

namespace EmailWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<EmailController> _logger;
        public EmailController(IEmailService emailService, ILogger<EmailController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }


        [Route("send")]
        [HttpPost]
        public ActionResult SendEmail([FromBody]CreateNewEmailDto email)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _emailService.Create(email);
                    return Ok();
                }

                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                const string message = ("Error occurred.");
                _logger.LogError(ex, message);
                return StatusCode((int)HttpStatusCode.BadRequest, new { ex.Message });

            }
        }

        [Route("update")]
        [HttpPut]
        public ActionResult UpdateCurrentEmail([FromBody]UpdateEmailDto updateEmailData)
        {
            try
            {
                _emailService.Update(updateEmailData);
                return Ok();
            }
            catch (Exception ex)
            {
                const string message = ("Error occurred.");
                _logger.LogError(ex, message);
                return StatusCode((int)HttpStatusCode.BadRequest, new { ex.Message });

            }
        }

        [Route("delete")]
        [HttpDelete]
        public ActionResult DeleteCurrentEmail(int emailId)
        {
            try
            {
                _emailService.DeleteById(emailId);
                return Ok();
            }
            catch (Exception ex)
            {
                const string message = ("Error occurred.");
                _logger.LogError(ex, message);
                return StatusCode((int)HttpStatusCode.BadRequest, new { ex.Message });

            }
        }

        [Route("query/emails")]
        [HttpPost]
        public ActionResult FetchAllEmails(EmailSearchModel filters)
        {
            try
            {
                return new JsonResult(_emailService.GetAllUserEmails(filters));
            }
            catch (Exception ex)
            {
                const string message = ("Error occurred.");
                _logger.LogError(ex, message);
                return StatusCode((int)HttpStatusCode.BadRequest, new { ex.Message });

            }
        }
    }
}
