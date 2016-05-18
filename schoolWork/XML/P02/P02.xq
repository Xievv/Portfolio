xquery version "1.0";

<html>
	<head>
		<title>US House of Reps</title>
	</head>
	<body>
		<h2>First and Last names of House of Rep Members sorted by last name and party:</h2>

		<div class="Republicans" style="display: inline-block; vertical-align:top;">
			<h3>Republicans</h3>
			<ol>
				{
					for $x in doc("congress/USHouseOfReps.xml")/MemberData/members/member/member-info
					where $x/party="R"
					order by $x/party, $x/lastname
			
					return <li>{data($x/firstname)}&#32;{data($x/lastname)},&#32;{data($x/state/state-fullname)},&#32;{data($x/party)}</li>
				}
			</ol>
		</div>


		<div class="Democrat" style="display: inline-block; vertical-align:top;">
			<h3>Democrats</h3>
			<ol>
				{
					for $x in doc("congress/USHouseOfReps.xml")/MemberData/members/member/member-info
					where $x/party="D"
					order by $x/party, $x/lastname
			
					return <li>{data($x/firstname)}&#32;{data($x/lastname)},&#32;{data($x/state/state-fullname)},&#32;{data($x/party)}</li>
				}
			</ol>
		</div>
	</body>
</html>