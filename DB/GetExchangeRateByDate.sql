CREATE FUNCTION GetExchangeRateByDate
(
	@date DATETIME2,
	@currencyIsoCode NVARCHAR(MAX)
)
RETURNS TABLE 
AS
RETURN 
(
	SELECT * FROM ExchangeRate er
	INNER JOIN Currencys c ON c.[Code] = er.[CurrencyCode]
	WHERE er.Date = @date 
	AND c.[IsoCharCode] = @currencyIsoCode
)