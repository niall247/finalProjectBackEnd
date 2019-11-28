using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CityReviewGuide.Repositories;
using CityReviewGuide.Repositories.Domain;
using Microsoft.Extensions.Logging;
using System.Data.SqlClient;


namespace CityReviewGuide.Repositories
{
    public class ReviewsRepository
    {

        private  ILogger _logger;
         public string ConnString = @"Server=HiddeninPublicRepoContactForDetails,1433;Database=cityguidedb;";    
        //  public

        public ReviewsRepository(ILogger myLog)
        {

            _logger = myLog;
        }

        public List<CityReview> returnReviews(string category)
        {

            try

            {
               


                SqlConnectionStringBuilder build = new SqlConnectionStringBuilder(ConnString);
                build.UserID = "IhaveHiddenthisinthispublicrepository";
                build.Password = @"IhaveHiddenthisinthispublicrepository";

                string connstring = build.ConnectionString;


            List<CityReview> myReviews = new List<CityReview>();

            using (SqlConnection conn = new SqlConnection(connstring))

            {
               // conn.ConnectionString = ConnString;
                  
                    conn.Open();

                 
                SqlCommand cmd = new SqlCommand(@"SELECT * FROM CityReviews", conn);

                SqlDataReader reader = cmd.ExecuteReader();
                

                string a = "";
                while (reader.Read())
                {
                    CityReview myReview = new CityReview();
                    myReview.ReviewID = (int)reader[0];
                    myReview.ReviewCategory = reader[1].ToString();
                    myReview.ReviewItemID = (int)reader[2];
                    myReview.ReviewRating = reader[3].ToString();
                    myReview.ReviewText = reader[4].ToString();
                    myReviews.Add(myReview);
                }

                    conn.Close();

                }

                

                return myReviews;

                
            }
            catch(Exception e)
            {

                _logger.LogError(e.InnerException.ToString());
                return null;

            }


        }

        public void returnReview (int id)
        {

        }

        public void addReview(CityReview c)
        {
            SqlConnectionStringBuilder build = new SqlConnectionStringBuilder(ConnString);
            build.UserID = "IhaveHiddenthisinthispublicrepository";
            build.Password = @"IhaveHiddenthisinthispublicrepository";

            string connstring = build.ConnectionString;

            using(SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                string sql = @"INSERT INTO CityReviews(ReviewCategory,ReviewItemID,ReviewRating,ReviewText)";
                sql += @"VALUES('" + c.ReviewCategory + "'," + c.ReviewItemID + ",'" + c.ReviewRating + "','" + c.ReviewText + "');";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

           
        }

    }
}
