using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using Labs.Data;
using Labs.infrastructure;
using Labs.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Labs.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly LabsContext _context;
        private readonly IMapper _mapper;

        public LabController(LabsContext dbContext, IMapper mapper)
        {
            _context = dbContext;
            _mapper = mapper;
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser model)
        {
            try
            {

                if (await _context.users.AnyAsync(f => f.UserName == model.UserName.ToLower()))
                {
                    return StatusCode(400, new
                    {
                        code = 400,
                        message = " Exist",
                        result = (object)null
                    });
                }
                var user = _mapper.Map<User>(model);

                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();

                return StatusCode(200, new
                {
                    code = 200,
                    message = " Successfuly Created",
                    result = new
                    {
                        ID = user.ID,
                        Name = user.UserName,
                        Role = user.RoleID
                    }

                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("createLab")]
        public async Task<IActionResult> CreateLab([FromBody] CreateLabAccount model)
        {
            try
            {

                if (await _context.Labs.AnyAsync(f => f.LabName == model.LabName.ToLower()))
                {
                    return StatusCode(400, new
                    {
                        code = 400,
                        message = " Exist",
                        result = (object)null
                    });
                }
                var lab = _mapper.Map<Lab>(model);

                await _context.Labs.AddAsync(lab);
                await _context.SaveChangesAsync();

                return StatusCode(200, new
                {
                    code = 200,
                    message = " Successfuly Created",
                    result = new
                    {
                        ID = lab.ID,
                        Name = lab.LabName
                    }

                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            try
            {
                //if (!ModelState.IsValid)
                //{
                //    return StatusCode(400, new
                //    {
                //        code = 400_001,
                //        message = "invalid parameters",
                //        result = (object)null
                //    });
                //}


                var user = await _context.users.AsNoTracking().Where(f => f.UserName.ToLower()==model.UserName.ToLower()&&f.Password==model.Password
                && f.isDeleted != true).Select(f=>new {f.ID,f.RoleID,f.UserName,f.Password,f.LabID}).FirstOrDefaultAsync();

                //if (user == null)
                //{
                //    return StatusCode(400, new
                //    {
                //        code = 400_001,
                //        message = "User not exsits",
                //        result = (object)null
                //    });
                //}
                //if (!JwtAuth.Tools.Hasher.Compare(user.Password, model.Password))
                //{
                //    return StatusCode(400, new
                //    {
                //        code = 400_002,
                //        message = "User not exsits",
                //        result = (object)null
                //    });
                //}




                return StatusCode(200, new
                {
                    code = 200,
                    message = "successfuly login",
                    result = new
                    {
                        UserID = user.ID,
                        UserName = user.UserName,
                        RoleID = user.RoleID,
                        LabID= user.LabID



                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpPost("AddTest")]
        public async Task<IActionResult> AddTest([FromBody] AddTests model)
        {
            try
            {

                if (await _context.tests.AnyAsync(f => f.TestName == model.TestName.ToLower()))
                {
                    return StatusCode(400, new
                    {
                        code = 400,
                        message = " Exist",
                        result = (object)null
                    });
                }
                var test = _mapper.Map<Test>(model);

                await _context.tests.AddAsync(test);
                await _context.SaveChangesAsync();

                return StatusCode(200, new
                {
                    code = 200,
                    message = " Successfuly Created",
                    result = new
                    {
                        ID = test.ID,
                        Name = test.TestName
                    }

                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("AddDate")]
        public async Task<IActionResult> AddDate([FromBody] DatesModel model)
        {
            try
            {

                if (await _context.dates.AnyAsync(f => f.Date == model.Date))
                {
                    return StatusCode(400, new
                    {
                        code = 400,
                        message = " Exist",
                        result = (object)null
                    });
                }
                var date = _mapper.Map<Dates>(model);

                await _context.dates.AddAsync(date);
                await _context.SaveChangesAsync();

                return StatusCode(200, new
                {
                    code = 200,
                    message = " Successfuly Created",
                    result = new
                    {
                        ID = date.ID,
                        Date = date.Date,
                        booked = date.isBooked
                    }

                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("BookAtest")]
        public async Task<IActionResult> BookAtest([FromBody] BookATest model)
        {

            var Book = _mapper.Map<LabDateTest>(model);
            var lu = new List<LabTest>();
            foreach (var t in model.TestID)
            {
                lu.Add(new LabTest() { TestID = t });
                await _context.lt.AddAsync(new LabTest() { TestID = t, LabID = Book.LabID });
                await _context.SaveChangesAsync();
            }


            await _context.Ldts.AddAsync(Book);
            await _context.SaveChangesAsync();





            return StatusCode(200, new
            {
                code = 200_002,
                message = " Successfuly Created",
                result = new
                {
                    ID = Book.ID,
                    Name = Book.FullName,




                }
            });
        }
        [HttpGet("GetTest")]
        public async Task<IActionResult> GetTestByLabID(int ID)
        {
            try
            {
                var Tests = await _context.tests.AsNoTracking().Where(c => c.LabID == ID && c.IsDeleted == false).Select(f => new
                {
                    f.ID,
                    f.TestName
                }).ToListAsync();
                return StatusCode(200, new
                {
                    code = 200,
                    message = " Successfuly",
                    result = new
                    {
                        Tests,

                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var labs = await _context.Labs.Where(d => d.isDeleted == false).Select(f => new { f.ID, f.LabName }).ToListAsync();
                return StatusCode(200, new
                {
                    code = 200,
                    message = " Successfuly",
                    result = new
                    {
                        labs,

                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("GetDate")]
        public async Task<IActionResult> GetDateByLabID(int ID)
        {
            try
            {
                var Dates = await _context.dates.AsNoTracking().Where(c => c.LabID == ID && c.isBooked == false).Select(f => new
                {
                    f.ID,
                    f.Date,
                    f.isBooked
                    
                }).ToListAsync();
                return StatusCode(200, new
                {
                    code = 200,
                    message = " Successfuly",
                    result = new
                    {
                        Dates,

                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("BookDate")]
        public async Task<IActionResult> Booking(int ID)
        {
            var date = await _context.dates.FirstOrDefaultAsync(f => f.ID == ID);
            if (date == null)
                return StatusCode(404, new
                {
                    code = 404_002,
                    message = "Not Exist",
                    result = (object)null
                });
            date.isBooked = true;

            await _context.SaveChangesAsync();
            return Ok(date.isBooked);
        }

        [HttpDelete("Booktime")]
        public async Task<IActionResult> Bookin(int ID)
        {
            var date = await _context.times.FirstOrDefaultAsync(f => f.TimeID == ID);
            if (date == null)
                return StatusCode(404, new
                {
                    code = 404_002,
                    message = "Not Exist",
                    result = (object)null
                });
            if (date.isAvailable == false) date.isAvailable = true;
            else date.isAvailable = false;

            await _context.SaveChangesAsync();
            return Ok(date.isAvailable);
        }
        [HttpGet("GetBookedTests")]
        public async Task<IActionResult> BookedTest(int ID)
        {try
            {
                var labs = await _context.Ldts.Where(d => d.IsDeleted == false && d.LabID == ID).Select(f => new { f.ID, f.FullName, f.Email, f.age,f.Time.time, f.Date,f.IsDone, test = f.lab.Lt.Select(d => d.test.TestName).FirstOrDefault() }).ToListAsync();
                return StatusCode(200, new
                {
                    code = 200,
                    message = " Successfuly",
                    result = new
                    {
                        labs,

                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ShowUser")]
        public async Task<IActionResult> showuser()
        {
            var users = await _context.users.Select(f => new
            {
                f.ID,
                f.UserName,
                f.Name,
                f.isDeleted,
                f.Phone,
                f.RoleID,
                lap= _context.Labs.AsNoTracking().Where(d=>d.ID==f.LabID).Select(s=>s.LabName).ToList()
            }).ToListAsync();
            return StatusCode(200, new
            {
                code = 200,
                message = " done",
                result = new
                {
                    users
                }
            });
            
        }

        [HttpGet("Dashboard")]
        public async Task<IActionResult> dashboard()
        {
            var users = await _context.users.AsNoTracking().Where(f => f.RoleID == 2 && f.isDeleted == false).CountAsync();
            var lab = await _context.Labs.AsNoTracking().Where(f => f.isDeleted == false).CountAsync();
            var test = await _context.tests.AsNoTracking().Where(f => f.IsDeleted == false).CountAsync();
            var Booked_Test = await _context.dates.AsNoTracking().Where(f => f.IsDeleted == false && f.isBooked == true).CountAsync();
            var not_booked = await _context.dates.AsNoTracking().Where(f => f.IsDeleted == false && f.isBooked == false).CountAsync();
            var done = await _context.Ldts.AsNoTracking().Where(f => f.IsDeleted == false && f.IsDone == true).CountAsync();
            var notdone = await _context.Ldts.AsNoTracking().Where(f => f.IsDeleted == false && f.IsDone == false).CountAsync();


            return StatusCode(200, new
            {
                code = 200,
                message = " Successfuly",
                result = new
                {
                    users,
                    lab,
                    test,
                    Booked_Test,
                    not_booked,
                    done,
                    notdone

                }
            });
        }
        [HttpDelete("DoneTest")]
        public async Task<IActionResult> Done(int ID)
        {
            var test = await _context.Ldts.FirstOrDefaultAsync(f => f.ID == ID);
            if (test == null)
                return StatusCode(404, new
                {
                    code = 404_002,
                    message = "Not Exist",
                    result = (object)null
                });
            test.IsDone = true;

            await _context.SaveChangesAsync();
            return Ok(test.IsDone);
        }

        [HttpDelete("deleteUser")]
        public async Task<IActionResult> deleteuser(int ID)
        {

            var user = await _context.users.FirstOrDefaultAsync(f => f.ID == ID);
            if (user == null)
                return StatusCode(404, new
                {
                    code = 404_002,
                    message = "Not Exist",
                    result = (object)null
                });

            if (user.isDeleted == false) user.isDeleted = true;
            else user.isDeleted = false;

            await _context.SaveChangesAsync();
            return Ok(user.isDeleted);
        }
        [HttpDelete("deleteLab")]
        public async Task<IActionResult> deletelab(int ID)
        {

            var lab = await _context.Labs.FirstOrDefaultAsync(f => f.ID == ID);
            if (lab == null)
                return StatusCode(404, new
                {
                    code = 404_002,
                    message = "Not Exist",
                    result = (object)null
                });

            if (lab.isDeleted == false) lab.isDeleted = true;
            else lab.isDeleted = false;

            await _context.SaveChangesAsync();
            return Ok(lab.isDeleted);
        }
        [HttpDelete("deleteTest")]
        public async Task<IActionResult> deleteTest(int ID)
        {

            var test = await _context.tests.FirstOrDefaultAsync(f => f.ID == ID);
            if (test == null)
                return StatusCode(404, new
                {
                    code = 404_002,
                    message = "Not Exist",
                    result = (object)null
                });
            test.IsDeleted = true;

            await _context.SaveChangesAsync();
            return Ok(test.IsDeleted);
        }
        [HttpDelete("deleteadate")]
        public async Task<IActionResult> deltedate(int ID)
        {

            var dates = await _context.dates.FirstOrDefaultAsync(f => f.ID == ID);
            if (dates == null)
                return StatusCode(404, new
                {
                    code = 404_002,
                    message = "Not Exist",
                    result = (object)null
                });

            dates.IsDeleted = true;


            await _context.SaveChangesAsync();
            return Ok(dates.IsDeleted);
        }

        [HttpDelete("deleteBooked")]
        public async Task<IActionResult> deletebooked(int ID)
        {

            var booked = await _context.Ldts.FirstOrDefaultAsync(f => f.ID == ID);
            if (booked == null)
                return StatusCode(404, new
                {
                    code = 404_002,
                    message = "Not Exist",
                    result = (object)null
                });

            booked.IsDeleted = true;


            await _context.SaveChangesAsync();
            return Ok(booked.IsDeleted);
        }

        [HttpGet("GetTimes")]
        public async Task<IActionResult>gettime()
        {
            var Times = await _context.times.AsNoTracking().Select(d =>
            new { 
                d.TimeID,
                d.time,
                d.isAvailable,
            }).ToListAsync();

            return StatusCode(200, new
            {
                code = 200,
                message = " done",
                result = new
                {
                    Times
                }
            });
        }



    } 
}