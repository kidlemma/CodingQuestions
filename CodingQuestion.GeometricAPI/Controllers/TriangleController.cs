using CodingQuestion.Common.Exception;
using CodingQuestion.Entity;
using CodingQuestion.GeometricAPI.ExceptionFilter;
using CodingQuestion.GeometricInterface;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodingQuestion.GeometricAPI.Controllers
{
    [RoutePrefix("api")]
    [ApiExceptionFilterAttribute]
    public class TriangleController : ApiController
    {
        private readonly ITriangleService _triangleService;
        public TriangleController(ITriangleService triangleService)
        {
            _triangleService = triangleService;
        }

        [HttpGet]
        [Route("triangle/coordinate")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IList<Coordinate>))]
        public IHttpActionResult GetCoordinate(char row, int column)
        {

            ValidateRowAndColumn(row, column);

            var result = _triangleService.GetCoordinate(row, column);

            return Ok(result);

        }

        [HttpPost]
        [Route("triangle/Location")]
        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(Cell))]
        public IHttpActionResult GetTriangleLocation(IList<Coordinate> coordinates)
        {

            ValidateCoordinate(coordinates);

            var result = _triangleService.GetTriangleLocation(coordinates);

            return Ok(result);

        }



        private void ValidateRowAndColumn(char row, int column)
        {
            if (char.ToUpper(row) < 'A' || char.ToUpper(row) > 'F')
            {
                throw new ApiException(HttpStatusCode.BadRequest, $"the row '{row}' should be b/n A and F.");
            }
            if (column < 1 || column > 12)
            {
                throw new ApiException(HttpStatusCode.BadRequest, $"the column '{column}' should be b/n 1 and 12.");
            }
        }
        private void ValidateCoordinate(IList<Coordinate> coordinates)
        {
            //verify as it has 3 coordinates
            if (coordinates?.Count != 3)
            {
                throw new ApiException(HttpStatusCode.BadRequest, $"Invalid number of coordinate");
            }

            //verify as all the cordinates are with in the 60X60p
            if (!ModelState.IsValid)
            {
                throw new ApiException(HttpStatusCode.BadRequest, $"Invalid Coordinates");
            }

            //TODO: verify the coordinates are a valid triangle
        }
    }
}
