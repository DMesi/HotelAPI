using AutoMapper;
using HotelAPI.IRepository;
using HotelAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPI.Data;

namespace HotelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;

        public HotelController(IUnitOfWork unitOfWork, ILogger<HotelController> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotels()
        {
            try
            {
                var hotels = await _unitOfWork.Hotels.GetAll();
                var results = _mapper.Map<List<HotelDTO>>(hotels);
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wronk un the {nameof(GetHotels)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }

        }
       
        [HttpGet("{id:int}", Name ="GetHotel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetHotel(int id)
        {
            try
            {
                var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id, new List<string> { "Country" });
                var result = _mapper.Map<HotelDTO>(hotel);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wronk un the {nameof(GetHotel)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later.");
            }

        }

      
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDTO hotelDTO)
        {
            if (!ModelState.IsValid)
            {

                _logger.LogError($"Invalid POST atempt in {nameof(CreateHotel)}");
                return BadRequest(ModelState);

            }

            try
            {
                var hotel = _mapper.Map<Hotel>(hotelDTO);
                await _unitOfWork.Hotels.Insert(hotel);
                await _unitOfWork.Save();

                return CreatedAtRoute("GetHotel", new { id = hotel.Id },hotel);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(CreateHotel)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }

        }


       
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelDTO hotelDTO)
        {
            if (!ModelState.IsValid || id<1)
            {

                _logger.LogError($"Invalid UPDATE atempt in {nameof(UpdateHotel)}");
                return BadRequest(ModelState);

            }

            


            try
            {
                var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id);
                if(hotel == null)
                {
                    _logger.LogError($"Invalid UPDATE atempt in {nameof(UpdateHotel)}");
                    return BadRequest("Submitted data is invalid");


                }
                _mapper.Map(hotelDTO, hotel);
                _unitOfWork.Hotels.Update(hotel);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(UpdateHotel)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }

        }


      
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (id < 1)
            {

                _logger.LogError($"Invalid DELETE atempt in {nameof(DeleteHotel)}");
                return BadRequest(ModelState);

            }
            try
            { 
                var hotel = await _unitOfWork.Hotels.Get(q => q.Id == id);
                if (hotel == null)
                {
                    _logger.LogError($"Invalid DELETE atempt in {nameof(DeleteHotel)}");
                    return BadRequest("Submitted data is invalid");
                }

                await _unitOfWork.Hotels.Delete(id);
                await _unitOfWork.Save();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Something Went Wrong in the {nameof(DeleteHotel)}");
                return StatusCode(500, "Internal Server Error. Please Try Again Later");
            }


        }

    }
}
