﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MySocialMedia.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();
        //public BaseContoller(IMediator mediator)
        //{
        //    _mediator = mediator;
            
        //}
        
    }
}
