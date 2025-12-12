#Permission
# AWS SSM（Parameter Store）利用時の IAM 設定まとめ

## ① C# で AWS SDK（SSM）を利用

以下の名前空間を使用：

``` csharp
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
```

------------------------------------------------------------------------

## ② IAM エラー発生

    because no permissions boundary allows the ssm:GetParameter action

→ 許可ポリシーではなく **Permissions Boundary** が原因。

------------------------------------------------------------------------

## ③ ks2 に設定されていた Boundary

    AWSQuickSetupSSMHostMgmtPermissionsBoundary

→ AWS Quick Setup が自動作成した Boundary。\
→ **SSM を許可していなかったため、常に拒否されていた。**

------------------------------------------------------------------------

## ④ Permission Boundary の役割

AWS 権限は 2 段階：

1.  **許可ポリシー（Allow）**\
2.  **Permissions Boundary（最大許可の上限）**

Boundary が拒否していると、Allow があっても拒否される。

------------------------------------------------------------------------

## ⑤ 新しい Boundary を作成（TestBoundary）

``` json
{
  "Version": "2012-10-17",
  "Statement": [
    {
      "Effect": "Allow",
      "Action": "*",
      "Resource": "*"
    }
  ]
}
```

------------------------------------------------------------------------

## ⑥ ks2 の Boundary を付け替え

元の Boundary：

    AWSQuickSetupSSMHostMgmtPermissionsBoundary

これを **MyWideBoundaryPolicy** に変更、または削除。

------------------------------------------------------------------------

## ⑦ 許可ポリシー（Permission Policy）を設定

ks2 に次を付与：

-   `AmazonSSMReadOnlyAccess`

Boundary が許すようになったため、SSM 呼び出しが成功。

------------------------------------------------------------------------

## ⑧ 結果

C# の `GetParameterAsync()` が正常に動作。

------------------------------------------------------------------------

## ■ まとめ（要点）

-   エラー原因：**Boundary が SSM を許可していなかった**
-   対応：Boundary を修正 or 削除
-   設定：`AmazonSSMReadOnlyAccess` を付与
-   結果：SSM パラメータ取得成功