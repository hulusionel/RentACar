using RentACar.Model.EntityModels;

namespace Interfaces.AbstractModels
{
    public interface IEmployeeService:IGenericService<Employees>
    {
        Employees EmployeeLogin(string UserName, string Password);
    }
}
