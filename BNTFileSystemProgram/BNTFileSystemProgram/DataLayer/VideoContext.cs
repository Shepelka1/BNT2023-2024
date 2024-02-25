using BussinessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class VideoContext
    {
        private readonly ApplicationDbContext dbContext;

        public VideoContext(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public async Task CreateAsync(Video item)
        {
            try
            {
                dbContext.Videos.Add(item);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Video> ReadAsync(string key, bool useNavigationalProperties = false, bool isReadOnly = true, bool forIndex = false)
        {
            try
            {
                IQueryable<Video> query = dbContext.Videos;

                if (useNavigationalProperties)
                {
                    query = query.Include(v => v.Format);
                    if (!forIndex)
                        query = query.Include(v => v.Tags)
                            .Include(v => v.Authors)
                            .Include(v => v.Genres);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.FirstOrDefaultAsync(v => v.VideoId == key);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Video>> ReadAllAsync(bool useNavigationalProperties = false, bool isReadOnly = true, bool forIndex = false)
        {
            try
            {
                IQueryable<Video> query = dbContext.Videos;

                if (useNavigationalProperties)
                {
                    query = query.Include(v => v.Format);
                    if (!forIndex)
                        query = query.Include(v => v.Tags)
                            .Include(v => v.Authors)
                            .Include(v => v.Genres);
                }

                if (isReadOnly)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task UpdateAsync(Video item, bool useNavigationalProperties = false)
        {
            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteAsync(string key)
        {
            try
            {
                var videoFromDb = await ReadAsync(key, false, false);

                if (videoFromDb == null)
                {
                    throw new ArgumentException("The video with this Id does not exist");
                }

                dbContext.Videos.Remove(videoFromDb);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void LoadNavigation(Video item)
        {
            dbContext.Entry(item).Collection(v => v.Tags).Load();
            dbContext.Entry(item).Collection(v => v.Authors).Load();
            dbContext.Entry(item).Collection(v => v.Genres).Load();
        }
    }
}
