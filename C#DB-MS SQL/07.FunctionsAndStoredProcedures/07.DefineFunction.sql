CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT=1;
	DECLARE @Letter CHAR(1)
	WHILE(LEN(@word) >= @i)
		BEGIN
			SET @Letter=SUBSTRING(@word,@i,1)
			IF (@setOfLetters NOT LIKE '%'+@Letter+'%')
				RETURN 0
			SET @i+=1
		END
	RETURN 1
END


SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')
SELECT dbo.ufn_IsWordComprised('oistmiahf', 'halves')
SELECT dbo.ufn_IsWordComprised('bobr', 'Rob')
SELECT dbo.ufn_IsWordComprised('pppp', 'Guy')