

using BlApi;

namespace BlImplementation
{
    internal class TaskImplementation : ITask
    {
        public int Create(BO.Task item)
        {

            DO.Student doStudent = new DO.Student
                (item.Id, boStudent.Name, boStudent.Alias, boStudent.IsActive, boStudent.BirthDate);
            try
            {
                int idStud = _dal.Student.Create(doStudent);
                return idStud;
            }
            catch (DO.DalAlreadyExistsException ex)
            {
                throw new BO.BlAlreadyExistsException($"Student with ID={boStudent.Id} already exists", ex);
            }

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public BO.Task? Read(int id)
        {
            throw new NotImplementedException();
        }

        public BO.Task? Read(Func<BO.Task, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.Task?> ReadAll(Func<BO.Task, bool>? filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(BO.Task item)
        {
            throw new NotImplementedException();
        }

        public void UpdateCalculatedEndDate(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateStatus(int id)
        {
            throw new NotImplementedException();
        }
    }
}
