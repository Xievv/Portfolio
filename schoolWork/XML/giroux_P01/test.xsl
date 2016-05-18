<xsl:stylesheet 
    xmlns:xs="http://www.w3.org/2001/XMLSchema"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="2.0"
    exclude-result-prefixes="xs">
<xsl:output method="html"/>
<xsl:template match="/">
<html>
<head>
<title>Additional Rep Information</title>
</head>
<body>
	<xsl:apply-templates select="MemberData/members/member/member-info[sort-name='YOUNG,DON']"/>
</body>
</html>

</xsl:template>

<xsl:template match="member-info">
	<h3><xsl:value-of select="firstname"/>&#160;<xsl:value-of select="lastname"/></h3>
	<p>District:&#160;<xsl:value-of select="district"/></p>
	<p>Office Building:&#160;<xsl:value-of select="office-building"/></p>
	<p>Office Room:&#160;<xsl:value-of select="office-room"/></p>
	<p>Elected Date:&#160;<xsl:value-of select="elected-date"/></p>
	<p>Sworn Date:&#160;<xsl:value-of select="sworn-date"/></p>
</xsl:template>
</xsl:stylesheet>