﻿using Dapper;
using MainMusicStore.Data;
using MainMusicStore.DataAccess.IMainRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainMusicStore.DataAccess.MainRepository
{
    public class SPCallRepository : ISPCallRepository
    {

        private readonly ApplicationDbContext _db;
        private static string connectionString = "";

        public SPCallRepository(ApplicationDbContext db)
        {
            _db = db;
            connectionString = db.Database.GetDbConnection().ConnectionString;
        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Execute(string procedurName, DynamicParameters parameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                sqlCon.Execute(procedurName, parameters, commandType:System.Data.CommandType.StoredProcedure);


            }
        }

        public IEnumerable<T> List<T>(string procedurName, DynamicParameters parameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                return  sqlCon.Query<T>(procedurName, parameters, commandType: System.Data.CommandType.StoredProcedure);


            }
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedurName, DynamicParameters parameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                var result = SqlMapper.QueryMultiple(sqlCon, procedurName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                //sql ile iletişimine bağlantı sağlamak için çoğlu query gönderiyoruz
                var item1 = result.Read<T1>().ToList();//okuma işlemini toList olarak dön
                var item2 = result.Read<T2>().ToList();

                if (item1 != null && item2 != null )
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }// çoklu ifade işlemleri oluşturuldu
}
            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }

        public T OneRecord<T>(string procedurName, DynamicParameters parameters = null)
        {
           using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                var value = sqlCon.Query(procedurName, parameters, commandType:System.Data.CommandType.StoredProcedure);
                   
                return (T)Convert.ChangeType(value.FirstOrDefault(),typeof(T));//dataya dönüşecek tipi verdik


            }
        }

        public T Single<T>(string procedurName, DynamicParameters parameters = null)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();


                return (T)Convert.ChangeType(sqlCon.ExecuteScalar<T>(procedurName,parameters,commandType:System.Data.CommandType.StoredProcedure),typeof(T));


            }
        }
    }
}
