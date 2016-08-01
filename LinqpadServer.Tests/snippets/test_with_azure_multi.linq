<Query Kind="Program">
  <Connection>
    <ID>8ef3e8a4-332f-4ef2-bdd9-d199152cde02</ID>
    <Server>40.86.86.37</Server>
    <SqlSecurity>true</SqlSecurity>
    <Database>DataA</Database>
    <UserName>lp_user</UserName>
    <Password>AQAAANCMnd8BFdERjHoAwE/Cl+sBAAAADh4LqJ9NLkioQcXzkBAcVAAAAAACAAAAAAAQZgAAAAEAACAAAABUHnjyZHtrPXMx4zZyuCGjMvXv4pvoW7d24AVsXZgOrgAAAAAOgAAAAAIAACAAAAAVJURMoT4XMcMzYUDiHFlalz8AoqB8E0kgKEn//oXDIRAAAACF21hRIxf0zx0xvKm5yH8cQAAAADi+bOXEMzK/tOgWidHHh4lE/CY1A4BEr4Et0kECJAqBTX1OyX6H8lecE1BCusacXuMd1Y4BfkDfA55WTOKXANY=</Password>
    <Persist>true</Persist>
    <LinkedDb>DataB</LinkedDb>
  </Connection>
  <Reference>&lt;RuntimeDirectory&gt;\System.Net.Http.dll</Reference>
  <NuGetReference>Newtonsoft.Json</NuGetReference>
  <Namespace>Dapper</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Linq</Namespace>
  <Namespace>System.Net.Http</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main(string[] args)
{
	if (args != null)
		foreach (var arg in args) arg.Dump();

	"Hello, world!".Dump();
	
	string.Join(",", TableAs.Select(t => t.Text)).Dump();
	string.Join(",", DataB.TableBs.Select(t => t.Text)).Dump();
}

// Define other methods and classes here