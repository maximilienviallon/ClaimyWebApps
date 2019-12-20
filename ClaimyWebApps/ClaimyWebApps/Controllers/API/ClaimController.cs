﻿using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using ClaimyWebApps.Dtos;
using ClaimyWebApps.Models;


namespace ClaimyWebApps.Controllers.API
{
    public class ClaimController : ApiController
    {
        private ApplicationDbContext _context;

        public ClaimController()
        {
            _context = new ApplicationDbContext();
            _context.Configuration.ProxyCreationEnabled = false;
        }
        
        // GET: api/Claim
        public IHttpActionResult Get(string query = null)
        {

            var claimQuery = _context.Claims.Include(c => c.Customer);
            if(!String.IsNullOrWhiteSpace(query))
            
                claimQuery = claimQuery.Where(c => c.CustomerEmail.Contains(query));

                var ClaimDtos = claimQuery.ToList().Select(Mapper.Map<Claim, ClaimDto>);

                return Ok(ClaimDtos);
        }

        //Post /api/claim
        [HttpPost]
        public IHttpActionResult CreateClaim(ClaimDto claimDto)
        {

            var claim = Mapper.Map<ClaimDto, Claim>(claimDto);
            _context.Claims.Add(claim);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + claim.ID), claimDto);
        }


        // PUT: api/Claim/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Claim/5
        public void Delete(int id)
        {
        }

        [HttpPut]
        public IHttpActionResult UpdateClaim(int id, ClaimDto claimDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var claimInDb = _context.Claims.SingleOrDefault(c => c.ID == id);

            if (claimInDb == null)
                return NotFound();

            Mapper.Map(claimDto, claimInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteClaim(int id)
        {
            var claimInDb = _context.Claims.SingleOrDefault(c => c.ID == id);

            if (claimInDb == null)
                return NotFound();

            _context.Claims.Remove(claimInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
