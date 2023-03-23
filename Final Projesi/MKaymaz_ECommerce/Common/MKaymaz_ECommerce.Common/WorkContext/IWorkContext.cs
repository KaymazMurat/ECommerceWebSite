using MKaymaz_ECommerce.Common.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace MKaymaz_ECommerce.Common.WorkContext
{
    public interface IWorkContext
    {
        UserResponseDto CurrentUser { get; set; }
    }
}
