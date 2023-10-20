using Common.DataTransferObjects;
using Common.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels;
public class HomeIndexVM {
    public IDataResult<List<SavedPasswordDto>> SavedPasswords { get; set; }
    public IDataResult<List<CategoryDto>> Categories { get; set; }
}
