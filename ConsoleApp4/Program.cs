var hosts = new string[6] { "unlock.microvirus.md", "visitwar.com", "visitwar.de", "fruonline.co.uk", "australia.open.com", "credit.card.us" };
var forbiddentHosts = new string[4] { "microvirus.md", "visitwar.de", "piratebay.co.uk", "list.stolen.credit.card.us" };
var res = GetAllowedHostIndexes(hosts, forbiddentHosts);

foreach (var item in res)
    Console.WriteLine(item);

int[] GetAllowedHostIndexes(string[] A, string[] B)
{
    var forbiddenHosts = new HashSet<string>(B);
    var allowedHostIndexes = new int[A.Length];
    int count = 0;

    for (int i = 0; i < A.Length; i++)
    {
        var subdomains = A[i].Split('.');

        for (int j = subdomains.Length - 2; j >= 0; j--)
        {
            var host = string.Join(".", subdomains, j, subdomains.Length - j);

            if (forbiddenHosts.Contains(host))
                break;

            if (j == 0)
            {
                allowedHostIndexes[count] = i;
                count++;
            }
        }
    }
    Array.Resize(ref allowedHostIndexes, count);
    return allowedHostIndexes;
}