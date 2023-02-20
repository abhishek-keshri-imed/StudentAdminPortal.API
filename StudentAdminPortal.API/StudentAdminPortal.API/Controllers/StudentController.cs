using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.DomainModels;
using StudentAdminPortal.API.Repositories;

namespace StudentAdminPortal.API.Controllers
{
    [ApiController]
    public class StudentController : Controller
    {
        private readonly IStudentRepository studentRepository;
        private readonly IMapper mappper;

        public StudentController(IStudentRepository studentRepository,IMapper mapper) 
        {
         this.studentRepository=studentRepository;
            this.mappper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public  async Task< IActionResult> GetAllStudents()
        {
            /*

            // From DataMaodels :
            // return Ok( studentRepository.GetStudents());
               
                var students = studentRepository.GetStudents();

            //From DomainModels :
                var domainModelsStudents = new List<Student>();
                foreach (var student in students) 
                    {
                    
                        domainModelsStudents.Add(new Student()
                        {
                            Id= student.Id,
                            FirstName= student.FirstName,
                            LastName= student.LastName,
                            DateOfBirth= student.DateOfBirth,
                            Email= student.Email,
                            Mobile= student.Mobile,
                            ProfileImageUrl= student.ProfileImageUrl,
                            GenderId= student.GenderId,
                            Address=new Address()
                            {
                                Id=student.Address.Id,
                                PhysicalAddress=student.Address.PhysicalAddress,
                                PostalAddress=student.Address.PostalAddress,
                            },
                            Gender =new Gender()
                            {
                                Id= student.Gender.Id,
                                Description= student.Gender.Description,    

                            }

                        });
                    }
            */
            var students = await studentRepository.GetStudentsAsync();
            return Ok(mappper.Map<List<Student>>(students));

        }
    }
}
