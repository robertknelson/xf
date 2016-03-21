// <copyright file="Selection.cs" company="eXtensoft, LLC">
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

    public class SelectionMDG : SqlServerModelDataGateway<Selection>
    {

        #region local fields

        private const string SelectionIdParamName = "@selectionid";
        private const string DisplayParamName = "@display";
        private const string TokenParamName = "@token";
        private const string SortParamName = "@sort";
        private const string GroupIdParamName = "@groupid";
        private const string MasterIdParamName = "@masterid";

        #endregion local fields

        #region SqlCommand overrides

        public override SqlCommand PostSqlCommand(SqlConnection cn, Selection model, IContext context)
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string sql = "insert into [dbo].[Selection] ( [Display],[Token],[Sort],[GroupId],[MasterId] ) values (" + DisplayParamName + "," + TokenParamName + "," + SortParamName + "," + GroupIdParamName + "," + MasterIdParamName + ")";

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue( DisplayParamName, model.Display );
            cmd.Parameters.AddWithValue( TokenParamName, model.Token );
            cmd.Parameters.AddWithValue( SortParamName, model.Sort );
            cmd.Parameters.AddWithValue( GroupIdParamName, model.GroupId );
            cmd.Parameters.AddWithValue( MasterIdParamName, model.MasterId );

            return cmd;
        }
        public override SqlCommand PutSqlCommand(SqlConnection cn, Selection model, ICriterion criterion, IContext context)
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string sql = "update [dbo].[Selection] set [Display] = " + DisplayParamName + " , [Token] = " + TokenParamName + " , [Sort] = " + SortParamName + " , [GroupId] = " + GroupIdParamName + " , [MasterId] = " + MasterIdParamName  + " where [SelectionId] = " + SelectionIdParamName ;


            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue( DisplayParamName, model.Display );
            cmd.Parameters.AddWithValue( TokenParamName, model.Token );
            cmd.Parameters.AddWithValue( SortParamName, model.Sort );
            cmd.Parameters.AddWithValue( GroupIdParamName, model.GroupId );
            cmd.Parameters.AddWithValue( MasterIdParamName, model.MasterId );

            return cmd;
        }
        public override SqlCommand DeleteSqlCommand(SqlConnection cn, ICriterion criterion, IContext context)
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string sql = "delete from [dbo].[Selection] where [SelectionId] = " + SelectionIdParamName;

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue( SelectionIdParamName, criterion.GetValue<int>("SelectionId") );

            return cmd;
        }
        public override SqlCommand GetSqlCommand(SqlConnection cn, ICriterion criterion, IContext context)
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string sql = "select [SelectionId], [Display], [Token], [Sort], [GroupId], [MasterId] from [dbo].[Selection] where [SelectionId] = " + SelectionIdParamName ;

            cmd.CommandText = sql;

            cmd.Parameters.AddWithValue( SelectionIdParamName, criterion.GetValue<int>("SelectionId") );

            return cmd;
        }
        public override SqlCommand GetAllSqlCommand(SqlConnection cn, ICriterion criterion, IContext context)
        {
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;

            string sql = "select [SelectionId], [Display], [Token], [Sort], [GroupId], [MasterId] from [dbo].[Selection] ";
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

        public override void BorrowReader(SqlDataReader reader, List<Selection> list)
        {
            while (reader.Read())
            {
                var model = new Selection();
                model.SelectionId = reader.GetInt32(reader.GetOrdinal("SelectionId"));
                model.Display = reader.GetString(reader.GetOrdinal("Display"));
                model.Token = reader.GetString(reader.GetOrdinal("Token"));
                model.Sort = reader.GetInt32(reader.GetOrdinal("Sort"));
                if (!reader.IsDBNull(reader.GetOrdinal("GroupId")))
                {
                    model.GroupId = reader.GetInt32(reader.GetOrdinal("GroupId"));
                }
                if (!reader.IsDBNull(reader.GetOrdinal("MasterId")))
                {
                    model.MasterId = reader.GetInt32(reader.GetOrdinal("MasterId"));
                }
                list.Add(model);

            }
        }

        #endregion Borrower overrides
    }
}
