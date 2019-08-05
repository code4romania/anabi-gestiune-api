using Anabi.Common.Utils;
using Anabi.Common.ViewModels;
using Anabi.DataAccess.Ef;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Anabi.Domain.Person.Commands
{
    public class AddOwner : AddOwnerRequest, IRequest<OwnerViewModel>
    {
        public int AssetId { get; set; }
    }
}
