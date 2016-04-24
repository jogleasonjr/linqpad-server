<Query Kind="Program" />

void Main(string[] args)
{
	if (args != null)
	{
		foreach (var arg in args)
		{
			arg.Dump();
		}
	}
	
	"Hello, world!".Dump();
}

// Define other methods and classes here