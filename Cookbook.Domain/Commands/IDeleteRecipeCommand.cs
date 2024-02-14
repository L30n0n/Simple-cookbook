using Cookbook.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookbook.Domain.Commands
{
    public interface IDeleteRecipeCommand
    {
        Task Execute(Guid id);
    }
}
