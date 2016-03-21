// <copyright file="Artifact.cs" company="eXtensoft, LLC">
// Copyright © 2016 All Right Reserved
// </copyright>

namespace Cyclops
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using System.Data;
    using System.Data.SqlClient;
    using XF.Common;
    using XF.DataServices;

    public class ArtifactMDG : SqlServerModelDataGateway<Artifact>
    {

        #region local fields

        private const string ArtifactIdParamName = "@artifactid";
        private const string IdParamName = "@id";
        private const string ArtifactTypeIdParamName = "@artifacttypeid";
        private const string MimeParamName = "@mime";
        private const string ContentLengthParamName = "@contentlength";
        private const string OriginalFilenameParamName = "@originalfilename";
        private const string LocationParamName = "@location";
        private const string TitleParamName = "@title";

        #endregion local fields

        #region SqlCommand overrides

        public override SqlCommand PostSqlCommand(SqlConnection cn, Artifact model, IContext context)
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string sql = "insert into [dbo].[Artifact] ( [Id],[ArtifactTypeId],[Mime],[ContentLength],[OriginalFilename],[Location],[Title] ) values (" + IdParamName + "," + ArtifactTypeIdParamName + "," + MimeParamName + "," + ContentLengthParamName + "," + OriginalFilenameParamName + "," + LocationParamName + "," + TitleParamName + ")";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue(IdParamName, model.Id);
            cmd.Parameters.AddWithValue(ArtifactTypeIdParamName, model.ArtifactTypeId);
            cmd.Parameters.AddWithValue(MimeParamName, model.Mime);
            cmd.Parameters.AddWithValue(ContentLengthParamName, model.ContentLength);
            cmd.Parameters.AddWithValue(OriginalFilenameParamName, model.OriginalFilename);
            cmd.Parameters.AddWithValue(LocationParamName, model.Location);
            cmd.Parameters.AddWithValue(TitleParamName, model.Title);

            return cmd;
        }
        public override SqlCommand PutSqlCommand(SqlConnection cn, Artifact model, ICriterion criterion, IContext context)
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string sql = "update [dbo].[Artifact] set [Id] = " + IdParamName + " , [ArtifactTypeId] = " + ArtifactTypeIdParamName + " , [Mime] = " + MimeParamName + " , [ContentLength] = " + ContentLengthParamName + " , [OriginalFilename] = " + OriginalFilenameParamName + " , [Location] = " + LocationParamName + " , [Title] = " + TitleParamName + " where [ArtifactId] = " + ArtifactIdParamName;


            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue(IdParamName, model.Id);
            cmd.Parameters.AddWithValue(ArtifactTypeIdParamName, model.ArtifactTypeId);
            cmd.Parameters.AddWithValue(MimeParamName, model.Mime);
            cmd.Parameters.AddWithValue(ContentLengthParamName, model.ContentLength);
            cmd.Parameters.AddWithValue(OriginalFilenameParamName, model.OriginalFilename);
            cmd.Parameters.AddWithValue(LocationParamName, model.Location);
            cmd.Parameters.AddWithValue(TitleParamName, model.Title);

            return cmd;
        }
        public override SqlCommand DeleteSqlCommand(SqlConnection cn, ICriterion criterion, IContext context)
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string sql = "delete from [dbo].[Artifact] where [ArtifactId] = " + ArtifactIdParamName;

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue(ArtifactIdParamName, criterion.GetValue<int>("ArtifactId"));

            return cmd;
        }
        public override SqlCommand GetSqlCommand(SqlConnection cn, ICriterion criterion, IContext context)
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string sql = "select [ArtifactId], [Id], [ArtifactTypeId], [Mime], [ContentLength], [OriginalFilename], [Location], [Title] from [dbo].[Artifact] where [ArtifactId] = " + ArtifactIdParamName;

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue(ArtifactIdParamName, criterion.GetValue<int>("ArtifactId"));

            return cmd;
        }
        public override SqlCommand GetAllSqlCommand(SqlConnection cn, ICriterion criterion, IContext context)
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string sql = "select [ArtifactId], [Id], [ArtifactTypeId], [Mime], [ContentLength], [OriginalFilename], [Location], [Title] from [dbo].[Artifact] ";
            cmd.CommandText = sql;

            return cmd;
        }
        public override SqlCommand GetAllProjectionsSqlCommand(SqlConnection cn, ICriterion criterion, IContext context)
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string sql = "";

            cmd.CommandText = sql;

            return cmd;
        }

        #endregion SqlCommand overrides

        #region Borrower overrides

        public override void BorrowReader(SqlDataReader reader, List<Artifact> list)
        {
            while (reader.Read())
            {
                var model = new Artifact();
                model.ArtifactId = reader.GetInt32(reader.GetOrdinal("ArtifactId"));
                model.Id = reader.GetGuid(reader.GetOrdinal("Id"));
                model.ArtifactTypeId = reader.GetInt32(reader.GetOrdinal("ArtifactTypeId"));
                model.Mime = reader.GetString(reader.GetOrdinal("Mime"));
                model.ContentLength = reader.GetInt64(reader.GetOrdinal("ContentLength"));
                model.OriginalFilename = reader.GetString(reader.GetOrdinal("OriginalFilename"));
                model.Location = reader.GetString(reader.GetOrdinal("Location"));
                model.Title = reader.GetString(reader.GetOrdinal("Title"));
                list.Add(model);

            }
        }

        #endregion Borrower overrides
    }
}
