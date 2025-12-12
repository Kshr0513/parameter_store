using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using System;
using System.Reflection.Metadata.Ecma335;

class Program
{
   static async Task Main()
    {
        //パラメータストアへアクセスするクライアントを作成
        var ssm = new AmazonSimpleSystemsManagementClient();

        try
        {
            //パラメータストアからパラメータを取得
            var response = await ssm.GetParameterAsync(new GetParameterRequest
            {
                Name = "param-name",
                WithDecryption = true
            });

            string value = response.Parameter.Value;
            Console.WriteLine($"Value: {value}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine("取得成功");
        }
    } 
}