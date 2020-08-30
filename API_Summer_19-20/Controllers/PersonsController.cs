using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Summer_19_20.Controllers
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
    }
    public class PersonsController : ApiController
    {
        List<Person> persons = new List<Person>()
        {
            new Person(){ Id=1001, Name="abc", Salary=35000},
            new Person(){ Id=1002, Name="xyz", Salary=45000}
        };

        public IHttpActionResult Get()
        {
            return Ok(persons);
        }

        public IHttpActionResult Get(int id)
        {
            Person p = persons.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(p);
        }

        public IHttpActionResult Post(Person p)
        {
            //persons.Id = 1003;
            persons.Add(p);
            return Ok(persons);
        }

        public IHttpActionResult Put(Person p, int id)
        {
            var oldPerson = persons.Where(x => x.Id == id)
                                   .FirstOrDefault();
            if (oldPerson != null)
            {
                oldPerson.Id = p.Id;
                oldPerson.Name = p.Name;
                oldPerson.Salary = p.Salary;

            }
            else
            {
                return NotFound();
            }
            return Ok(persons);
        }


        public IHttpActionResult Delete(int id)
        {
            var oldPerson = persons.Where(x => x.Id == id)
                                   .FirstOrDefault();
            if (oldPerson == null)
            {
                return NotFound();
            }
            else
            {
                persons.Remove(oldPerson);
                return Ok(persons);
            }
        }
    }
}
