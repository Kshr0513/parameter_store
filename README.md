# parameter_store
## AWS SSM　パラメータストア学習用ソリューション
***
### 行ったこと
***
* vscodeに拡張機能の追加
 * C# Dev Kit
 * .NET Extension Pack
 * AWS Toolkit for VS Code
***
* C#プロジェクト作成
 * `dotnet new console -n ProjectName`
 * ディレクトリ内にAWS SDKをNuGetパッケージとして追加
 * `dotnet add package AWSSDK.SimpleSystemsManagement`
***
* AWSクレデンシャルを設定
 * `aws configure`
  * AWS Access Key ID [None]: {アクセスキーID}
  * AWS Secret Access Key [None]: {シークレットアクセスキー}
  * Default region name [None]: ap-northeast-1 最寄りのリージョン
  * Default output format [None]: json