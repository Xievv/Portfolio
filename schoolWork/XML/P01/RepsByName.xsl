<xsl:stylesheet 
xmlns:xs="http://www.w3.org/2001/XMLSchema"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0"
exclude-result-prefixes="xs">
<xsl:output method="html"/>
<xsl:template match="/">
<html>
	<head>
	<link rel="stylesheet" href="style.css" type="text/css"/>
	<title>Members of the US House of Reps</title>
	</head>
	<body>
		<div class="wrapper">
			<div class="navbar">
				<!-- Links don't work, they're more for design, since it's not a full website -->
				<a href="#">Representatives</a>
				<a href="#">Leadership</a>
				<a href="#">Committees</a>
				<a href="#">Legislative Activity</a>
				<a href="#">The House Explained</a>
			</div>
			<div class="container">
				<div class="sort">
					<p>
						Sort&#160;by:&#160;
						<a href="USHouseOfRepsName.xml">Name</a>&#160;
						<a href="USHouseOfRepsState.xml">State</a>&#160;
						<a href="USHouseOfRepsParty.xml">Party</a>
					</p>
				</div>
				<xsl:apply-templates select="MemberData/members/member/member-info" mode="list">
					<xsl:sort select="sort-name" order="ascending"/>
				</xsl:apply-templates>
			</div>
		</div>
	</body>
</html>

</xsl:template>
<xsl:template match="member-info" mode="list">
<div class="repSeats">
	<p>
		<xsl:choose>
			<xsl:when test="namelist=''">
				<b>State&#160;District:</b>&#160;<xsl:value-of select="../statedistrict"/>
				<p><b>Status:</b>&#160;<xsl:value-of select="footnote"/></p>
			</xsl:when>
			<xsl:otherwise>
				<b><xsl:value-of select="namelist"/></b>
				-&#160;(<xsl:value-of select="party"/>&#160;-&#160;<xsl:value-of select="state/@postal-code"/>)
				<p>
					<xsl:value-of select="townname"/>,&#160;<xsl:value-of select="state"/>
				</p>
				<p>
					<xsl:value-of select="phone"/>
				</p>
			</xsl:otherwise>
		</xsl:choose>
	</p>
</div>
</xsl:template>
</xsl:stylesheet>