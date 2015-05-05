using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OpenDataDBBuilder.Business.DB.VO;
using OpenDataDBBuilder.Business.VO;

namespace OpenDataDBBuilder.Business.File.Util
{
    public class FileUtil
    {
        public FileUtil(){}

        public static void createFile(String filePath, String content)
        {
            if (!System.IO.File.Exists(filePath))
            {
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(content);
                    fs.Write(info, 0, info.Length);
                }
            }

        }


        public static void overWriteFile(String filePath, String content)
        {
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                using (FileStream fs = System.IO.File.Create(filePath))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(content);
                    fs.Write(info, 0, info.Length);
                }
            }

        }

        public static List<String> openFile(String filePath)
        {
            StreamReader reader = new StreamReader(new FileStream(filePath,FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
            String line = "";
            List<String> file = new List<String>();
            int counter = 0;

            while ((line = reader.ReadLine()) != null)
            {
                file.Add(line);
                counter++;
            }
            return file;
        }
        public static int countLines(String filePath)
        {
            int counter = 0;
             try
             {
                StreamReader reader = new StreamReader(new FileStream(filePath,FileMode.Open, FileAccess.Read, FileShare.ReadWrite));          
                while (reader.ReadLine() != null)
                {
                  counter++;
                }
            }
            catch (Exception e)
            {
                Console.Out.Write(e);
            }

             return counter;
        }


        public String extractNodeName(char[] line)
        {
	        String node = "";
	        Boolean ok = false;
	        foreach( char c in line)
            {
		        if(c == '>' || (ok && c==' '))
                {
			        break;
		        }
		        if(ok)
                {
			        node = c == '/' ? node += c : "";
		        }
		        if(c == '<')
                {
			        ok = true;
		        }
	        }
            return node;
        }

        public static int countPages(int lines, int pageSize)
        {
            int pages = 0;
            if (lines > 0 && pageSize > 0)
            {
                Decimal pagesD = Decimal.Parse(lines.ToString()) / Decimal.Parse(pageSize.ToString());
                return (int)Decimal.Ceiling(pagesD);
            }
            return pages;
        }

        public static string readLines(string filePath, int page, int pageSize)
        {
            int counter = 0;
            int initLine = 0;
            String line = "";
            String file = "";
            if (page < 1)
                return "";
            else if (page  > 1)
                initLine = (page - 1) * pageSize;
            try
            {
                StreamReader reader = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite));
                while ((line = reader.ReadLine()) != null)
                {
                    if (counter >= initLine)
                    {
                        if (counter <= (initLine + pageSize) - 1)
                            file += line + "\n";
                        else
                            break;
                    }
                    counter++;
                }
            }
            catch (Exception e)
            {
                Console.Out.Write(e);
            }
            return file;
        }

        public static Table getTableFromFile(String filePath)
        {
            int counter = 0;
            String line = "";
            Table table = new Table();
            table.Columns = new List<Column>();
            table.Rows = new List<Row>();

            try
            {
                StreamReader reader = new StreamReader(new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite), Encoding.Default);
                while ((line = reader.ReadLine()) != null)// && counter < 50)
                {
                    String[] fields = line.Split(';');
                    if (counter == 0)
                    {
                        int i = 1;
                        foreach (String s in fields)
                        {
                            table.Columns.Add(new Column("column" + i));
                            i++;
                        }
                    }
                    Row row = new Row();
                    row.Values = new List<KeyValue>();
                    int index = 1;
                    foreach (String s in fields)
                    {
                        row.Values.Add(new KeyValue("column"+index, s.Replace("\"", "")));
                        index++;
                    }
                    table.Rows.Add(row);
                    counter++;
                }
            }
            catch (Exception e)
            {
                Console.Out.Write(e);
            }
            table.TableName = "Table1";
            return table;
        }
    }
}
