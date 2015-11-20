using System;
using SchemaExplorer;
using System.Data;
using CodeSmith.Engine;
using System.Text.RegularExpressions;

public class ToolsCodeTemplate:CodeTemplate
{
    public string GetCsharpType(ColumnSchema column)
	{
		if (column.Name.EndsWith("TypeCode")) return column.Name;
		string type;
		switch (column.DataType)
		{
			case DbType.AnsiString: type= "string";break;
			case DbType.AnsiStringFixedLength: type= "string";break;
			case DbType.Binary: type= "byte[]";break;
			case DbType.Boolean: type= "bool";break;
			case DbType.Byte: type= "byte";break;
			case DbType.Currency: type= "decimal";break;
			case DbType.Date: type= "DateTime";break;
			case DbType.DateTime: type= "DateTime";break;
			case DbType.Decimal: type= "decimal";break;
			case DbType.Double: type= "double";break;
			case DbType.Guid: type= "Guid";break;
			case DbType.Int16: type= "short";break;
			case DbType.Int32: type= "int";break;
			case DbType.Int64: type= "long";break;
			case DbType.Object: type= "object";break;
			case DbType.SByte: type= "sbyte";break;
			case DbType.Single: type= "float";break;
			case DbType.String: type= "string";break;
			case DbType.StringFixedLength: type= "string";break;
			case DbType.Time: type= "TimeSpan";break;
			case DbType.UInt16: type= "ushort";break;
			case DbType.UInt32: type= "uint";break;
			case DbType.UInt64: type= "ulong";break;
			case DbType.VarNumeric: type= "decimal";break;
			default:
			{
				type= "__UNKNOWN__" + column.NativeType;
				break;
			}
		}
//		if(column.AllowDBNull && column.SystemType.IsValueType)
//		{
//			type=type+"?";
//		}
		return type;
	}
    
    public string GetConvert(ColumnSchema column)
    {
        if (column.Name.EndsWith("TypeCode")) return column.Name;
        
        switch (column.DataType)
        {
            case DbType.AnsiString: return "Convert.ToString";
            case DbType.AnsiStringFixedLength: return "Convert.ToString";
            case DbType.Binary: return "Convert.ToByte";
            case DbType.Boolean: return "Convert.ToBoolean";
            case DbType.Byte: return "Convert.ToInt32";
            case DbType.Currency: return "Convert.ToDecimal";
            case DbType.Date: return "Convert.ToDateTime";
            case DbType.DateTime: return "Convert.ToDateTime";
            case DbType.Decimal: return "Convert.ToDecimal";
            case DbType.Double: return "Convert.ToDouble";
            case DbType.Guid: return "Convert.ToString";
            case DbType.Int16: return "Convert.ToInt16";
            case DbType.Int32: return "Convert.ToInt32";
            case DbType.Int64: return "Convert.ToInt64";
            case DbType.Object: return "Convert.ToString";
            case DbType.SByte: return "Convert.ToByte";
            case DbType.Single: return "Convert.ToInt32";
            case DbType.String: return "Convert.ToString";
            case DbType.StringFixedLength: return "Convert.ToString";
            case DbType.Time: return "Convert.DateTime";
            case DbType.UInt16: return "Convert.ToUInt16";
            case DbType.UInt32: return "Convert.ToUInt32";
            case DbType.UInt64: return "Convert.ToUInt64";
            case DbType.VarNumeric: return "Convert.ToDecimal";
            default:
            {
                return "__UNKNOWN__" + column.NativeType;
            }
        }
    }
    
    public string GetSqlDbType(ColumnSchema column)
    { 
    	switch (column.NativeType.ToLower()) 
    	{ 
        	case "bigint": return "SqlDbType.BigInt"; 
        	case "binary": return "SqlDbType.Binary"; 
        	case "bit": return "SqlDbType.Bit"; 
        	case "char": return "SqlDbType.Char"; 
        	case "datetime": return "SqlDbType.DateTime"; 
        	case "decimal": return "SqlDbType.Decimal"; 
        	case "float": return "SqlDbType.Float"; 
        	case "image": return "SqlDbType.Image"; 
        	case "int": return "SqlDbType.Int"; 
        	case "money": return "SqlDbType.Money"; 
        	case "nchar": return "SqlDbType.NChar"; 
        	case "ntext": return "SqlDbType.NText"; 
        	case "numeric": return "SqlDbType.Decimal"; 
        	case "nvarchar": return "SqlDbType.NVarChar"; 
        	case "real": return "SqlDbType.Real"; 
        	case "smalldatetime": return "SqlDbType.SmallDateTime"; 
        	case "smallint": return "SqlDbType.SmallInt"; 
        	case "smallmoney": return "SqlDbType.SmallMoney"; 
        	case "sql_variant": return "SqlDbType.Variant"; 
        	case "sysname": return "SqlDbType.NChar"; 
        	case "text": return "SqlDbType.Text"; 
        	case "timestamp": return "SqlDbType.Timestamp"; 
        	case "tinyint": return "SqlDbType.TinyInt"; 
        	case "uniqueidentifier": return "SqlDbType.UniqueIdentifier"; 
        	case "varbinary": return "SqlDbType.VarBinary"; 
        	case "varchar": return "SqlDbType.VarChar"; 
        	default: return "__UNKNOWN__" + column.NativeType; 
    	} 
    }
    
    public string GetDefaultValue(ColumnSchema column)
    {
        if (column.Name.EndsWith("TypeCode")) return column.Name;
        switch (column.DataType)
        {
            case DbType.AnsiString: return "\"\"";
            case DbType.AnsiStringFixedLength: return "\"\"";
            case DbType.Binary: return "null";
            case DbType.Boolean: return "false";
            case DbType.Byte: return "0";
            case DbType.Currency: return "0";
            case DbType.Date: return "DateTime.Parse(\"1900-1-1\")";
            case DbType.DateTime: return "DateTime.Parse(\"1900-1-1\")";
            case DbType.Decimal: return "0";
            case DbType.Double: return "0";
            case DbType.Guid: return "Guid.NewGuid().ToString()";
            case DbType.Int16: return "0";
            case DbType.Int32: return "0";
            case DbType.Int64: return "0";
            case DbType.Object: return "\"\"";
            case DbType.SByte: return "0";
            case DbType.Single: return "0";
            case DbType.String: return "\"\"";
            case DbType.StringFixedLength: return "";
            case DbType.Time: return "DateTime.Parse(\"1900-1-1\")";
            case DbType.UInt16: return "0";
            case DbType.UInt32: return "0";
            case DbType.UInt64: return "0";
            case DbType.VarNumeric: return "0";
            default:
            {
            return "__UNKNOWN__" + column.NativeType;
            }
        }
    }
    
    public bool IsIdentity(ColumnSchema column)
    {
        if((bool)column.ExtendedProperties["CS_IsIdentity"].Value) 
		{
			return true;
		}
        else
        {
            return false;
        }
    }
    
    public bool HasIdentity(TableSchema table)
    {
        foreach(ColumnSchema column in table.Columns)
    	{
    		if((bool)column.ExtendedProperties["CS_IsIdentity"].Value) 
    		{
    			return true;
    		}
    	}
    	return false;
    }
    
    public ColumnSchema GetPKColumn(TableSchema table)
    {
        if (table.HasPrimaryKey)
		    return table.PrimaryKey.MemberColumns[0];
		return null;
    }
    
    public string GetPKName(TableSchema table)
	{
		if (table.HasPrimaryKey)
		    return table.PrimaryKey.MemberColumns[0].Name;
		return null;
	}
	
	public string GetPKType(TableSchema table)
	{
		if (table.HasPrimaryKey)
		    return GetCsharpType(table.PrimaryKey.MemberColumns[0]);
		return null;
	}
    
    public string GetPKSqlType(TableSchema table)
    {
        if (table.HasPrimaryKey)
		    return GetSqlDbType(table.PrimaryKey.MemberColumns[0]);
		return null;
    }
    
    public string GetPKSize(TableSchema table)
    {
        if (table.HasPrimaryKey)
		    return table.PrimaryKey.MemberColumns[0].Size.ToString();
		return null;
    }
    
    public ColumnSchema GetIdentityColumn(TableSchema table)
    {
        ColumnSchema c=null;
        foreach(ColumnSchema column in table.Columns)
    	{
    		if((bool)column.ExtendedProperties["CS_IsIdentity"].Value) 
    		{
    			c= column;
    		}
    	}
        
        return c;
    }
    
    public string GetIdentityType(TableSchema table)
    {
        if (table.HasPrimaryKey)
		    return GetCsharpType(GetIdentityColumn(table));
		return null;
    }
    
    public string GetFields(TableSchema table, bool insertIdentity=false)
    {
        string fields=null;
        foreach(var column in table.Columns)
        {
            if(insertIdentity==false)
            {
                if(!IsIdentity(column))
                {
                    fields+="["+column.Name+"]";
                    fields+=",";
                }
            }
            else
            {
                fields+="["+column.Name+"]";
                fields+=",";
            }
        }
        
        return fields.Substring(0,fields.Length-1);
    }
    
    public string GetValues(TableSchema table, bool insertIdentity=false)
    {
        string values=null;
        foreach(var column in table.Columns)
        {
            if(insertIdentity==false)
            {
                if(!IsIdentity(column))
                {
                    values+="@"+column.Name;
                    values+=",";
                }
            }
            else
            {
                values+="@"+column.Name;
                values+=",";
            }
        }
        
        return values.Substring(0,values.Length-1);
    }
    
    public string GetValuesEquals(TableSchema table, bool insertIdentity=false)
    {
        string values=null;
        foreach(var column in table.Columns)
        {
            if(insertIdentity==false)
            {
                if(!IsIdentity(column))
                {
                    values+="["+column.Name+"]=@"+column.Name;
                    values+=",";
                }
            }
            else
            {
                values+="["+column.Name+"]=@"+column.Name;
                values+=",";
            }
        }
        
        return values.Substring(0,values.Length-1);
    }
    
    public string GetFields_NoPI(TableSchema table)
    {
        string fields=null;
        foreach(var column in table.Columns)
        {
            if(!IsIdentity(column) && column.IsPrimaryKeyMember==false)
            {
                fields+="["+column.Name+"]";
                fields+=",";
            }
        }
        return fields.Substring(0,fields.Length-1);
    }
    
    public string GetValuesEquals_NoPI(TableSchema table)
    {
        string values=null;
        foreach(var column in table.Columns)
        {
            if(!IsIdentity(column) && column.IsPrimaryKeyMember==false)
            {
                values+="["+column.Name+"]=@"+column.Name;
                values+=",";
            }
        }
        return values.Substring(0,values.Length-1);
    }
    
    public void PrintHeader(string descript = null)
	{
		Response.WriteLine("    //============================================================================");
		Response.WriteLine("    // Author: yet");
        Response.WriteLine("    // CreateDate: "+ DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
        Response.WriteLine("    // Descript: " + descript);
        Response.WriteLine("    // ");
		Response.WriteLine("    //============================================================================");
	}
    
}