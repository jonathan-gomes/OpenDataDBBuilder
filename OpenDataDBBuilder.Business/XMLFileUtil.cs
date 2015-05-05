using System;
using System.Xml;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDataDBBuilder.Business;
using OpenDataDBBuilder.Business.File.Util;
using OpenDataDBBuilder.Business.DB.VO;
using OpenDataDBBuilder.Business.VO;

namespace OpenDataDBBuilder.Business.File.XML.Util
{
    public class XMLFileUtil : FileUtil
    {
        static ClassUtil classUtil = new ClassUtil();
        public static bool IsValidXML(String filepath, out String validationMessage)
        {
            try
            {
                if (string.IsNullOrEmpty(filepath) == false)
                {
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.Load(getXMLReader(filepath));
                    validationMessage = "";
                    return true;
                }
                else
                {
                    validationMessage = "";
                    return false;
                }
            }
            catch (System.Xml.XmlException xe)
            {
                Console.Out.Write(xe.Message);
                validationMessage = xe.Message;
                return false;
            }
        }



        private static XmlReader getXMLReader(String filePath) 
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ConformanceLevel = ConformanceLevel.Fragment;
            settings.IgnoreWhitespace = true;
            settings.IgnoreComments = true;
            return XmlReader.Create(filePath, settings);
        }

        public static List<Table> getTablesFromXMLFile(String filePath)
        {
            XElement xml = XElement.Load(getXMLReader(filePath));
            Console.Out.Write(xml.Name);
            Table table = null;
            Row row = null;
            List<Table> tables = new List<Table>();
            int count = 0;
            foreach(XElement x in xml.Elements())
            {
              //  if (count >= 4)
                    //break;
                KeyValue value = null;
                row = null;
                if (x.Elements().Count() > 0)
                {
                    foreach (XElement att in x.Elements())
                    {
                        value = new KeyValue();
                        value.Key = att.Name.ToString();
                        value.Value = (String)att.Value.ToString();
                        row =  classUtil.initializeIfNull(row);
                        row.Values = classUtil.initializeIfNull(row.Values);
                        row.Values.Add(value);
                        Column column = new Column(value.Key);

                        table = classUtil.initializeIfNull(table);
                        table.Columns = classUtil.initializeIfNull(table.Columns);

                        Boolean columnFound = false;
                        for (int i = 0; i < table.Columns.Count; i++)
                        {
                            if (table.Columns[i].ColumnName.Equals(column.ColumnName))
                                columnFound = true;
                        }
                        if(!columnFound)
                            table.Columns.Add(column);
                    }
                }
                else
                {
                    //value = new KeyValue();
                    //value.Key = x.Name.ToString();
                    //value.Value = (String)x.Value.ToString();
                    //row = classUtil.initializeIfNull(row);
                    //row.Values = classUtil.initializeIfNull(row.Values);
                    //row.Values.Add(value);
                }
                if (row != null)
                {
                    table = classUtil.initializeIfNull(table);
                    table.Rows = classUtil.initializeIfNull(table.Rows);
                    table.Rows.Add(row);
                    count++;
                }
               
            }
            if (table != null)
            {
                tables.Add(table);
            }
            return tables;
        }


        public static List<Table> getTablesFromXMLFileNew(String filePath)
        {
            XElement xml = XElement.Load(getXMLReader(filePath));
            Row row = new Row();
           
            //inicializa tabelas com a tabela do elemento root e add coluna do id do elemento root
            List<Table> tables = new List<Table>();

            addNodeToTables(xml, ref tables);
            
           // getTableRows(xml, ref tables, 50);
            
            return tables;
        }

        public static void getTableRows(XElement element, ref List<Table> tables, int maxRows)
        {
            int index = getElementIndexInTables(element, tables);
            if (index >= 0) //if table exists
            { 
                Table table = tables[index];
                table.Rows = new List<Row>();
                Row row = new Row();
                row.Values = new List<KeyValue>();

                foreach (Column c in table.Columns)
                {
                    if (c.IsIDGenerated)
                    {
                        if (c.IsFK)
                        {
                           // KeyValue value = new KeyValue(c.ColumnName, );
                            //row.Values.Add(value);
                        }
                        if (c.IsPK)
                        {
                            KeyValue value = new KeyValue(c.ColumnName, element.Element(c.ColumnName));
                            row.Values.Add(value);
                        }
                        
                    }
                }

                foreach (XElement x in element.Elements())
                {
                    if (x.HasElements)
                    {

                    }
                    else
                    {

                    }

                }
            }
        }


        public object getIDFromParentNodeTable(XElement element, ref List<Table> tables)
        {
            int index = getElementIndexInTables(element, tables);
            Column column = null;
            foreach (Column c in tables[index].Columns)
            {
                if (c.IsPK && c.IsIDGenerated)
                {
                    column = c;
                    break;
                }
            }

            foreach (Row r in tables[index].Rows)
            {
                //if (column.ColumnName.Equals(r.))
                //{
                //    column = c;
                //    break;
                //}
            }
            return null;
            
        }
        public static void addNodeToTables(XElement element, ref List<Table> tables)
        {
            int index = getElementIndexInTables(element, tables);
            if (index < 0) //if table do not yet exist
            {
                tables.Add(new Table(element.Name.ToString()));
                index = tables.Count - 1;
                tables[index].Columns = new List<Column>();
                String columnIDName = element.Name.ToString() + "ID";
                Column columnID = new Column(columnIDName, true, false, true,null);
                tables[index].Columns.Add(columnID);

                if (index > 0)//if not root node and is a child node to the root with children nodes of its own && (element.Parent.Parent == null && !element.HasElements)
                {
                    String parentName = element.Parent.Name.ToString();
                    String columnParentIDName = parentName + "ID";
                    String reference = parentName + "." + columnParentIDName;
                    Column columnParentID = new Column(columnParentIDName, false, true, true,reference);
                    tables[index].Columns.Add(columnParentID);
                }
            }
            foreach (XElement x in element.Elements())
            {
                if(x.HasElements)
                    addNodeToTables(x, ref tables);
                else
                    addNodeToRootTable(x, ref tables, index);
            }
        }

        public static void addNodeToRootTable(XElement element, ref List<Table> tables, int rootIndex)
        {
            Table table = tables[rootIndex];
            Boolean columnFound = false;

            foreach(Column c in table.Columns)
            {
                if (c.ColumnName.Equals(element.Name.ToString()))
                {
                    columnFound = true;
                    break;
                }
            }

            if (!columnFound)
                table.Columns.Add(new Column(element.Name.ToString()));

        }


        private static int getElementIndexInTables(XElement element, List<Table> tables)
        {
            int index = -1;
            int count = 0;
            foreach (Table t in tables)
            {
                if (t.TableName.Equals(element.Name.ToString()))
                {
                    index = count;
                    break;
                }
                count++;
            }
            return index;
        } 
    }

      
}
