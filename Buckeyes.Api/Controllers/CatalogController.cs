using Microsoft.AspNetCore.Mvc;
using Buckeyes.Domain.Catalog;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Buckeyes.Data;
using Microsoft.EntityFrameworkCore;

namespace Buckeyes.Api.Controllers {
    [ApiController]
    [Route("/catalog")]

    public class CatalogController: ControllerBase {
        
            private readonly StoreContext _db;
            public CatalogController(StoreContext db){
                _db = db;
            
        }
       
        /*
        [HttpGet]
        public IActionResult GetItems(){
            var items = new List<Item>() {
                new Item("Shirt", "Ohio State Shirt", "Nike", 29.99m),
                new Item("Shorts", "Ohio State Shorts", "Nike", 44.99m)
            };
            return Ok(items);
        }
        */

        [HttpGet]
        public IActionResult GetItems(){
            return Ok(_db.Items);
        }


        /*[HttpGet("{id:int}")]
        public IActionResult GetItem(int id) {
            var item = new Item("Shirt", "Ohio State Shirt", "Nike", 29.99m);
            item.Id = id;
            return Ok(item);
        }*/

        [HttpGet("{id:int}")]
        public IActionResult GetItem(int id) {
            var item = _db.Items.Find(id);
            if(item == null){
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
            return Created($"/catalog/{item.Id}", item);
        }

        /*[HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
            var item = new Item("Shirt", "Ohio State shirt", "Nike", 29.99m);
            item.Id = id;
            item.AddRating(rating);
            return Ok(item);
        }*/

        [HttpPost("{id:int}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating)
        {
        var item = _db.Items.Find(id);
        if(item == null){
            return NotFound();
        }

        item.AddRating(rating);
        _db.SaveChanges();

        return Ok(item);
        }

        [HttpPut("{id:int}")]
        public IActionResult Put(int id, Item item)
        {
            //return Ok(item);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            return NoContent();
        }

        /*[HttpPost("{id}/ratings")]
        public IActionResult PostRating(int id, [FromBody] Rating rating){
        var item = _db.Items.Find(id);
        if(item == null){
            return NotFound();
        }

        item.AddRating(rating);
        _db.SaveChanges();

        return Ok(item);  
    }*/

    [HttpPut("{id:int}")]
    public IActionResult PutItem(int id, [FromBody]Item item){
        if (id != item.Id){
            return BadRequest();
        }

        if(_db.Items.Find(id) == null){
            return NotFound();
        }

        _db.Entry(item).State = EntityState.Modified;
        _db.SaveChanges();
        return NoContent();

    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteItem(int id){
        var item = _db.Items.Find(id);
        if(item == null){
            return NotFound();
        }

        _db.Items.Remove(item);
        _db.SaveChanges();
        return Ok();
}
    
        }
    }