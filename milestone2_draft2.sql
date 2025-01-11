--drop database Telecom_Team_120;
Create database Telecom_Team_120;
go
use Telecom_Team_120;
go
CREATE PROCEDURE createAllTables
AS

    -- Creating Customer_Profile table
    CREATE TABLE  Customer_profile (
        nationalID INT PRIMARY KEY,
        first_name VARCHAR(50),
        last_name VARCHAR(50),
        email VARCHAR(50) UNIQUE,
        address VARCHAR(50),
        date_of_birth DATE
    );

    -- Creating Customer_Account table
    CREATE TABLE Customer_Account (
        mobileNo CHAR(11) PRIMARY KEY,
        pass VARCHAR(50),
        balance DECIMAL(10, 1),
        account_type VARCHAR(50),
        start_date DATE,
        status VARCHAR(50),
        point INT DEFAULT 0,
        nationalID INT,
        FOREIGN KEY (nationalID) REFERENCES Customer_profile(nationalID) ON DELETE CASCADE, 
        constraint chk_Customer_Account_status check(status = 'active' OR status = 'onhold'),
        constraint chk_Customer_Account_type check(account_type = 'Post Paid' OR account_type = 'Prepaid' OR account_type = 'Pay_as_you_go' )
    );

    -- Creating Service_Plan table
    CREATE TABLE Service_Plan (
        planID INT PRIMARY KEY IDENTITY(1,1),
        SMS_offered INT,
        minutes_offered INT,
        data_offered INT,
        name VARCHAR(50),
        price INT,
        description VARCHAR(50)
    );

    -- Creating Subscription table
    CREATE TABLE Subscription (
        mobileNo CHAR(11),
        planID INT,
        subscription_date DATE,
        status VARCHAR(50),
        FOREIGN KEY (mobileNo) REFERENCES Customer_Account(mobileNo) ON DELETE CASCADE ,
        FOREIGN KEY (planID) REFERENCES Service_Plan(planID) ON DELETE CASCADE ,
        constraint c1 Primary Key (mobileNo, planID),
        constraint chk_Subscribtion_status check(status= 'active' Or status= 'onhold' )
    );

    -- Creating Plan_Usage table
 CREATE TABLE Plan_Usage (
     usageID INT PRIMARY KEY IDENTITY(1,1),
     start_date DATE,
     end_date DATE,
     data_consumption INT,
     minutes_used INT,
     SMS_sent INT,
     mobileNo CHAR(11),
     planID INT,
     FOREIGN KEY (mobileNo) REFERENCES Customer_Account(mobileNo) ,
     FOREIGN KEY (planID) REFERENCES Service_Plan(planID),
     Constraint chk_dates check(end_date >= start_date)
 );

 -- Creating Payment table
 CREATE TABLE Payment (
     paymentID INT PRIMARY KEY IDENTITY(1,1),
     amount DECIMAL(10, 1),
     date_of_payment DATE,
     payment_method VARCHAR(50),
     status VARCHAR(50),
     mobileNo CHAR(11),
     FOREIGN KEY (mobileNo) REFERENCES Customer_Account(mobileNo) on delete cascade,
     constraint chk_Payment_status check(status = 'successful' OR status = 'pending' OR status = 'rejected' ) ,
     constraint chk_Payment_method check(payment_method = 'cash' OR payment_method = 'credit')
 );

 -- Creating Process_Payment table
 CREATE TABLE Process_Payment (
     paymentID INT Primary Key,
     planID INT,
     remaining_balance DECIMAL(10, 1), --look at schema
     extra_amount DECIMAL(10, 1), --look at schema
     FOREIGN KEY (paymentID) REFERENCES Payment(paymentID) on delete cascade ,
     FOREIGN KEY (planID) REFERENCES Service_Plan(planID) ,
     CONSTRAINT chk_balances CHECK (
        (remaining_balance > 0 AND extra_amount = 0) OR
        (extra_amount > 0 AND remaining_balance = 0) OR
        (remaining_balance = 0 AND extra_amount = 0)
    )
 );


 -- Creating Wallet table
 CREATE TABLE Wallet (
     walletID INT PRIMARY KEY IDENTITY(1,1),
     current_balance DECIMAL(10, 2) Default 0.00,
     currency VARCHAR(50),
     last_modified_date DATE,
     nationalID INT,
     mobileNo CHAR(11),
     FOREIGN KEY (nationalID) REFERENCES Customer_Profile(nationalID) ON DELETE CASCADE
 );

 -- Creating Transfer_money table
 CREATE TABLE Transfer_money (
     walletID1 INT,
     walletID2 INT,
     transfer_id INT  IDENTITY(1,1),
     amount DECIMAL(10, 2),
     transfer_date DATE,
     FOREIGN KEY (walletID1) REFERENCES Wallet(walletID) ,
     FOREIGN KEY (walletID2) REFERENCES Wallet(walletID) ,
     constraint c20 Primary key (walletID1, walletID2, transfer_id),
     CONSTRAINT chk_self_transfer CHECK (walletID1 <> walletID2), -- Prevent self-transfer
     CONSTRAINT chk_positive_amount CHECK (amount > 0 )            -- Ensure amount > 0
 );

 -- Creating Benefits table
 CREATE TABLE Benefits (
     benefitID INT PRIMARY KEY IDENTITY(1,1),
     description VARCHAR(50),
     validity_date DATE,
     status VARCHAR(50) Default 'active',
     mobileNo CHAR(11),
     FOREIGN KEY (mobileNo) REFERENCES Customer_Account(mobileNo) On Delete Cascade,
     constraint chk5 check(status = 'active' OR status = 'expired')
 );
 -- Creating Points_Group table
 CREATE TABLE Points_Group (
     pointID INT IDENTITY(1,1),
     benefitID INT ,
     pointsAmount INT default 0,
     paymentID INT,
     FOREIGN KEY (benefitID) REFERENCES Benefits(benefitID)  ON DELETE No Action,
     FOREIGN KEY (paymentID) REFERENCES Payment(paymentID)  ON DELETE No Action,
     constraint c2 primary key (pointID, benefitID)
 );


 -- Creating Exclusive_Offer table
 CREATE TABLE Exclusive_Offer (
     offerID INT IDENTITY(1,1),
     benefitID INT ,
     internet_offered INT default 0,
     SMS_offered INT default 0,
     minutes_offered INT default 0,
     FOREIGN KEY (benefitID) REFERENCES Benefits(benefitID) ON DELETE CASCADE,
     constraint c3 Primary key (offerID, benefitID)
 );

 -- Creating Cashback table
 CREATE TABLE Cashback (
     CashbackID INT IDENTITY(1,1),
     benefitID INT ,
     walletID INT,
     amount INT default 0,
     credit_date DATE,
     FOREIGN KEY (benefitID) REFERENCES Benefits(benefitID) ON DELETE CASCADE,
     FOREIGN KEY (walletID) REFERENCES Wallet(walletID) ON DELETE No Action,
     Constraint c4 Primary key (CashbackID, benefitID)
 );

 

 -- Creating Plan_Provides_Benefits table
 CREATE TABLE Plan_Provides_Benefits (
     benefitID INT ,
     planID INT,
     FOREIGN KEY (benefitID) REFERENCES Benefits(benefitID) ON DELETE CASCADE,
     FOREIGN KEY (planID) REFERENCES Service_Plan(planID) ON DELETE CASCADE,
     Constraint c5 primary key (benefitID, planID)
 );

 -- Creating Shop table
 CREATE TABLE Shop (
     shopID INT PRIMARY KEY IDENTITY(1,1),
     name VARCHAR(50),
     category VARCHAR(50)
 );
 -- Creating Physical_Shop table
 CREATE TABLE Physical_Shop (
     shopID INT PRIMARY KEY,
     address VARCHAR(50),
     working_hours VARCHAR(50),
     FOREIGN KEY (shopID) REFERENCES Shop(shopID) ON DELETE CASCADE
 );

 -- Creating E-shop table
 CREATE TABLE E_shop (
     shopID INT PRIMARY KEY,
     URL VARCHAR(50),
     rating INT,
     FOREIGN KEY (shopID) REFERENCES Shop(shopID) ON DELETE CASCADE
 );

 -- Creating Voucher table
 CREATE TABLE Voucher (
     voucherID INT PRIMARY KEY IDENTITY(1,1),
     value INT,
     expiry_date DATE,
     points INT CHECK (points >= 0),
     mobileNo CHAR(11),
     shopID INT,
     redeem_date DATE default null,
     FOREIGN KEY (mobileNo) REFERENCES Customer_Account(mobileNo) ON DELETE CASCADE,
     FOREIGN KEY (shopID) REFERENCES Shop(shopID) ON DELETE CASCADE
 );

 -- Creating Technical_Support_Ticket table
 CREATE TABLE Technical_Support_Ticket (
     ticketID INT IDENTITY(1,1),
     mobileNo CHAR (11),
     Issue_description VARCHAR(50),
     priority_level INT,
     status VARCHAR(50),
     FOREIGN KEY (mobileNo) REFERENCES Customer_Account(mobileNo) ON DELETE CASCADE,
     constraint chk6 check(status = 'open' OR status = 'In Progress' OR status = 'Resolved'),
     constraint c6 primary key(ticketID, mobileNo)

 );
 go
 exec createAllTables;

 go
 -- Extra procedure used to insert into Process_payment table to ensure that remaining_balance & extra_amount are calculated and derived correctly

 CREATE PROCEDURE InsertProcessPayment 
    @paymentID INT,
    @planID INT
AS
BEGIN
    DECLARE @amount DECIMAL(10, 2);
    DECLARE @price DECIMAL(10, 2);
    DECLARE @remaining_balance DECIMAL(10, 2);
    DECLARE @extra_amount DECIMAL(10, 2);

    -- Retrieve Payment.amount and Service_Plan.price
    SELECT @amount = p.amount
    FROM Payment p
    WHERE p.paymentID = @paymentID;

    SELECT @price = sp.price
    FROM Service_Plan sp
    WHERE sp.planID = @planID;

    -- Calculate remaining_balance and extra_amount
    IF @amount < @price
    BEGIN
        SET @remaining_balance = @price - @amount;
        SET @extra_amount = 0;
    END
    ELSE
    BEGIN
        SET @remaining_balance = 0;
        SET @extra_amount = @amount - @price;
    END

    -- Insert into Process_Payment
    INSERT INTO Process_Payment (paymentID, planID, remaining_balance, extra_amount)
    VALUES (@paymentID, @planID, @remaining_balance, @extra_amount);
END;

-- Example of insertion: EXEC InsertProcessPayment 1, 101;

go
-- a procedure used to insert any benefit in the Benefits table ensuring that a correct status is inserted as well. Cant be active if the validity date has already passed
CREATE PROCEDURE InsertBenefit
    @description VARCHAR(50),
    @validity_date DATE,
    @status VARCHAR(50),
    @mobileNo CHAR(11)
AS
BEGIN
    -- Step 1: Determine the expected status based on the validity_date
    DECLARE @expected_status VARCHAR(50);

    IF @validity_date >= GETDATE()
    BEGIN
        SET @expected_status = 'active';
    END
    ELSE
    BEGIN
        SET @expected_status = 'expired';
    END

    -- Step 2: Check if the provided status matches the expected status
    IF @status != @expected_status
    BEGIN
        PRINT 'Incorrect status for Benefit';
        RETURN;
    END

    -- Step 3: Insert the record if the status is correct
    INSERT INTO Benefits (description, validity_date, status, mobileNo)
    VALUES (@description, @validity_date, @status, @mobileNo);

    PRINT 'Benefit inserted successfully.';
END;
-- Example of insertion: EXEC InsertBenefit 'Exclusive Offer', '2024-12-31', 'active', '12345678901' 



go

CREATE PROCEDURE dropAllTables
AS

    DROP TABLE IF EXISTS Technical_Support_Ticket;
    DROP TABLE IF EXISTS Voucher;
    DROP TABLE IF EXISTS E_shop;
    DROP TABLE IF EXISTS Physical_Shop;
    DROP TABLE IF EXISTS Shop;
    DROP TABLE IF EXISTS Plan_Provides_Benefits;
    DROP TABLE IF EXISTS Cashback;
    DROP TABLE IF EXISTS Exclusive_Offer;
    DROP TABLE IF EXISTS Points_Group;
    DROP TABLE IF EXISTS Benefits;
    DROP TABLE IF EXISTS Transfer_money;
    DROP TABLE IF EXISTS Wallet;
    DROP TABLE IF EXISTS Process_Payment;
    DROP TABLE IF EXISTS Payment;
    DROP TABLE IF EXISTS Plan_Usage;
    DROP TABLE IF EXISTS Subscription;
    DROP TABLE IF EXISTS Service_Plan;
    DROP TABLE IF EXISTS Customer_Account;
    DROP TABLE IF EXISTS Customer_Profile;

go 



CREATE PROCEDURE dropAllProceduresFunctionsViews
AS

    -- Drop procedures
    DROP PROCEDURE IF EXISTS createAllTables;
    DROP PROCEDURE IF EXISTS dropAllTables;
    Drop Procedure if exists clearAllTables;
    Drop View if exists allCustomerAccounts;
    Drop View if exists allServicePlans;
    Drop view if exists allBenefits;
    Drop view if exists AccountPayments;
    Drop view if exists allShops;
    Drop view if exists allResolvedTickets;
    Drop view if exists CustomerWallet;
    Drop view if exists E_shopVouchers;
    Drop view if exists PhysicalStoreVouchers;
    Drop view if exists Num_of_cashback;
    Drop Procedure if exists Account_Plan;
    Drop Function if exists Account_Plan_date;
    Drop Function if exists Account_Usage_Plan;
    Drop Procedure if exists Benefits_Account;
    Drop Function if exists Account_SMS_Offers;
    Drop Procedure if exists Account_Payment_Points;
    Drop Function if exists Wallet_Cashback_Amount;
    Drop Function if exists Wallet_Transfer_Amount;
    Drop Function if exists Wallet_MobileNo;
    Drop Procedure if exists Total_Points_Account;
    Drop procedure if exists InsertProcessPayment;
    Drop procedure if exists InsertBenefit;
    Drop Function if exists AccountLoginValidation;
    Drop Function if exists Consumption;
    Drop procedure if exists Unsubscribed_Plans;
    Drop Function if exists Usage_Plan_CurrentMonth;
    Drop Function if exists Cashback_Wallet_Customer;
    Drop procedure if exists Ticket_Account_Customer;
    Drop procedure if exists Account_Highest_Voucher;
    Drop Function if exists Remaining_plan_amount;
    Drop Function if exists Extra_plan_amount;
    Drop procedure if exists Top_Successful_Payments;
    Drop Function if exists Subscribed_plans_5_Months;
    Drop procedure if exists Initiate_plan_payment;
    Drop procedure if exists Payment_wallet_cashback;
    Drop procedure if exists Initiate_balance_payment;
    Drop procedure if exists Redeem_voucher_points;

go

--exec dropAllProceduresFunctionsViews;

go

CREATE PROCEDURE clearAllTables
AS
    DELETE FROM Technical_Support_Ticket;
    DELETE FROM Voucher;
    DELETE FROM E_shop;
    DELETE FROM Physical_Shop;
    DELETE FROM Shop;
    DELETE FROM Plan_Provides_Benefits;
    DELETE FROM Cashback;
    DELETE FROM Exclusive_Offer;
    DELETE FROM Points_Group;
    DELETE FROM Benefits;
    DELETE FROM Transfer_money;
    DELETE FROM Wallet;
    DELETE FROM Process_Payment;
    DELETE FROM Payment;
    DELETE FROM Plan_Usage;
    DELETE FROM Subscription;
    DELETE FROM Service_Plan;
    DELETE FROM Customer_Account;
    DELETE FROM Customer_Profile;
go


-- View to retrieve details of active customer accounts:
CREATE VIEW allCustomerAccounts AS
SELECT CP.nationalID AS profile_nationalID,  -- Renaming duplicate column
    CP.first_Name,
    CP.last_Name,
    CP.email,
    cp.address,
    cp.date_of_birth,
    CA.mobileNo,
    ca.pass,
    cA.balance,
    ca.account_type,
    ca.start_date,
    ca.status,
    ca.point
    --CA.nationalID AS account_nationalID  
FROM Customer_profile CP
JOIN Customer_Account CA ON CP.nationalID  = CA.nationalID
WHERE CA.status = 'active';
go


CREATE VIEW allServicePlans AS
SELECT * FROM Service_Plan;

go

CREATE VIEW allBenefits AS
SELECT * FROM Benefits
WHERE status = 'active';

go



CREATE VIEW AccountPayments AS
SELECT p.paymentID, p.amount, p.date_of_payment, p.payment_method, p.status as payment_status, 
    CA.mobileNo,               -- Customer's mobile number
    CA.balance,                -- Customer's account balance
    CA.account_type,           -- Type of customer account
    CA.start_date,             -- Account start date
    CA.status AS account_status, -- Status of the customer account
    CA.point  
FROM Payment P 
JOIN Customer_Account CA ON P.mobileNo = CA.mobileNo;
go



CREATE VIEW allShops AS
SELECT * FROM Shop;
go

CREATE VIEW allResolvedTickets AS
SELECT * FROM Technical_Support_Ticket
WHERE status = 'Resolved';
go



CREATE VIEW CustomerWallet AS
SELECT W.*, CP.first_name, CP.last_name
FROM Wallet W
JOIN Customer_Profile CP ON W.nationalID = CP.nationalID;
go

CREATE VIEW E_shopVouchers AS
SELECT E.*, V.voucherID, V.value
FROM E_shop E
JOIN Voucher V ON E.shopID = V.shopID;
go

CREATE VIEW PhysicalStoreVouchers AS
SELECT P.*, V.voucherID, V.value
FROM Physical_Shop P
JOIN Voucher V ON P.shopID = V.shopID;
go

CREATE VIEW Num_of_cashback AS
SELECT walletID, COUNT(CashbackID) AS CashbackCount
FROM Cashback
GROUP BY walletID;

go

--2.3 points:

CREATE PROCEDURE Account_Plan AS

    SELECT CA.mobileNo, CA.account_type, CA.status AS account_status, S.planID, S.name AS plan_name
    FROM Customer_Account CA
    JOIN Subscription Sub ON CA.mobileNo = Sub.mobileNo
    JOIN Service_Plan S ON Sub.planID = S.planID

go



--To give access to the admin


CREATE FUNCTION Account_Plan_date (@Subscription_Date DATE, @Plan_id INT)
RETURNS TABLE
AS
RETURN (
    SELECT CA.mobileNo, S.planID, S.name AS plan_name
    FROM Subscription Sub
    JOIN Customer_Account CA ON Sub.mobileNo = CA.mobileNo
    JOIN Service_Plan S ON Sub.planID = S.planID
    WHERE Sub.subscription_date = @Subscription_Date AND S.planID = @Plan_id
);
go


--To give access to the admin

GO

CREATE FUNCTION Account_Usage_Plan (@MobileNo CHAR(11), @from_date DATE)
RETURNS TABLE
AS
RETURN (
    SELECT PU.planID, SUM(PU.data_consumption) AS total_data_consumed,
           SUM(PU.minutes_used) AS total_minutes_used,
           SUM(PU.SMS_sent) AS total_SMS
    FROM Plan_Usage PU
    WHERE PU.mobileNo = @MobileNo AND PU.start_date >= @from_date
    GROUP BY PU.planID
);
GO

CREATE PROCEDURE Benefits_Account @MobileNo CHAR(11), @planID INT AS
    with tmp3 as(
        SELECT Benefits.benefitID from Benefits WHERE mobileNo = @MobileNo AND EXISTS (
        SELECT * FROM Plan_Provides_Benefits PB WHERE PB.benefitID = Benefits.benefitID AND PB.planID = @planID
    ))

    DELETE FROM Points_Group WHERE benefitID IN (select benefitID from tmp3);
    DELETE FROM Exclusive_Offer WHERE benefitID IN (select benefitID from tmp3);
    DELETE FROM Cashback WHERE benefitID IN (select benefitID from tmp3);
    DELETE FROM Plan_Provides_Benefits WHERE benefitID IN (select benefitID from tmp3);

    DELETE FROM Benefits
    WHERE mobileNo = @MobileNo AND EXISTS (
        SELECT * FROM Plan_Provides_Benefits PB WHERE PB.benefitID = Benefits.benefitID AND PB.planID = @planID
    );
    

    select * from tmp3;
GO

CREATE FUNCTION Account_SMS_Offers (@MobileNo CHAR(11))
RETURNS TABLE
AS
RETURN (
    SELECT EO.offerID, EO.SMS_offered
    FROM Exclusive_Offer EO
    JOIN Benefits B ON EO.benefitID = B.benefitID
    WHERE B.mobileNo = @MobileNo AND EO.SMS_offered>0
);
go


CREATE PROCEDURE Account_Payment_Points @MobileNo CHAR(11) AS
    SELECT COUNT(*) AS total_transactions, SUM(pg.pointsAmount) AS total_points
    FROM Payment P
    JOIN Points_Group pg ON P.paymentID = pg.paymentID
    WHERE P.mobileNo = @MobileNo AND P.status = 'successful' AND P.date_of_payment >= DATEADD(YEAR, -1, GETDATE())
go 







CREATE FUNCTION Wallet_Cashback_Amount (@WalletID INT, @planID INT)
RETURNS DECIMAL(10, 1)
AS
BEGIN
    DECLARE @cashback_amount DECIMAL(10, 1);
    select  @cashback_amount = sum(c.amount)
    from Cashback c 
    join Plan_Provides_Benefits pb on pb.benefitID = c.benefitID
    where c.walletID = @WalletID AND pb.planID = @planID;
    RETURN @cashback_amount;
END;


go
CREATE FUNCTION Wallet_Transfer_Amount (
    @Wallet_id INT,
    @start_date DATE,
    @end_date DATE
)
RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @average_amount DECIMAL(10, 2);

    SELECT @average_amount = AVG(amount)
    FROM Transfer_money
    WHERE (walletID1 = @Wallet_id )
      AND transfer_date BETWEEN @start_date AND @end_date;

    RETURN @average_amount;
END; 
GO



CREATE FUNCTION Wallet_MobileNo (@MobileNo CHAR(11))
RETURNS BIT
AS
BEGIN
    DECLARE @isLinked BIT = 0;

    IF EXISTS (SELECT * FROM Wallet WHERE mobileNo = @MobileNo)
        SET @isLinked = 1;

    RETURN @isLinked;
END;
GO



CREATE PROCEDURE Total_Points_Account @MobileNo CHAR(11)
AS

    DECLARE @total_points INT = 0;

    -- Calculate the total points based on Payment transactions
    SELECT @total_points = ISNULL (SUM(pointsAmount),0)
    FROM Points_Group PG
    JOIN Payment P ON PG.PaymentID = P.paymentID
    WHERE P.mobileNo = @MobileNo;

   


    -- Update the points in the Customer_Account table
    UPDATE Customer_Account
    SET point = @total_points
    WHERE mobileNo = @MobileNo;

    -- Return the updated total points
    SELECT @total_points AS Total_Points;
GO
-- 1. Function: Login Validation
CREATE FUNCTION AccountLoginValidation 
(@MobileNo CHAR(11), @password VARCHAR(50) )
RETURNS BIT
AS
BEGIN
    DECLARE @isValid BIT = 0;

    IF EXISTS (SELECT * FROM Customer_Account WHERE mobileNo = @MobileNo AND pass = @password)
        SET @isValid = 1;

    RETURN @isValid;
END;
GO


-- 2. Function: Retrieve Consumption for an Input Plan Within a Certain Duration
CREATE FUNCTION Consumption (@Plan_name VARCHAR(50), @start_date DATE, @end_date DATE)
RETURNS TABLE
AS
RETURN (
    SELECT SUM(PU.data_consumption) AS total_data_consumption,
           SUM(PU.minutes_used) AS total_minutes_used,
           SUM(PU.SMS_sent) AS total_SMS_sent
    FROM Plan_Usage PU
    JOIN Service_Plan SP ON PU.planID = SP.planID
    WHERE SP.name = @Plan_name AND PU.start_date BETWEEN @start_date AND @end_date
);
GO

-- 3. Procedure: Retrieve Plans Not Subscribed to by the Customer
CREATE PROCEDURE Unsubscribed_Plans @MobileNo CHAR(11) AS

    SELECT SP.planID, SP.name, SP.price
    FROM Service_Plan SP
    WHERE SP.planID NOT IN (
        SELECT Sub.planID FROM Subscription Sub WHERE Sub.mobileNo = @MobileNo
    );

GO



-- 4. Function: Retrieve Current Month’s Usage for All Active Plans
CREATE FUNCTION Usage_Plan_CurrentMonth (@MobileNo CHAR(11))
RETURNS TABLE
AS
RETURN (
    SELECT PU.planID, SUM(PU.data_consumption) AS total_data, SUM(PU.minutes_used) AS total_minutes, SUM(PU.SMS_sent) AS total_SMS
    FROM Plan_Usage PU inner join Subscription sp on pu.planID = sp.planID
    WHERE PU.mobileNo = @MobileNo 
      AND MONTH(PU.start_date) = MONTH(GETDATE()) 
      AND YEAR(PU.start_date) = YEAR(GETDATE())
      And sp.status = 'active'
    GROUP BY PU.planID
);
GO



-- 5. Function: Retrieve Cashback Transactions for Customer's Wallet
CREATE FUNCTION Cashback_Wallet_Customer (@NationalID INT)
RETURNS TABLE
AS
RETURN (
    SELECT C.CashbackID, C.amount, C.credit_date
    FROM Cashback C
    JOIN Wallet W ON C.walletID = W.walletID
    WHERE W.nationalID = @NationalID
);
GO


-- 6. Procedure: Retrieve Number of Unresolved Technical Support Tickets
CREATE PROCEDURE Ticket_Account_Customer @NationalID INT AS

    SELECT COUNT(*) AS unresolved_tickets
    FROM Technical_Support_Ticket T
    JOIN Customer_Account CA ON T.mobileNo = CA.mobileNo
    WHERE CA.nationalID = @NationalID AND T.status <> 'Resolved';

GO


-- 7. Procedure: Retrieve the Highest Value Voucher for the Input Account
CREATE PROCEDURE Account_Highest_Voucher @MobileNo CHAR(11) AS

    SELECT TOP 1 voucherID
    FROM Voucher
    WHERE mobileNo = @MobileNo
    ORDER BY value DESC;

GO


-- 8. Function: Retrieve Remaining Amount for a Certain Plan
CREATE FUNCTION Remaining_plan_amount (@MobileNo CHAR(11), @plan_name VARCHAR(50))
RETURNS DECIMAL(10, 1)
AS
BEGIN
    DECLARE @remaining_amount DECIMAL(10, 1) = 0;
    

    SELECT TOP 1 @remaining_amount = SP.price - P.amount
    FROM Service_Plan SP
    join Process_Payment pp on sp.planID = pp.planID
    JOIN Payment P ON pp.paymentID = P.paymentID

    WHERE P.mobileNo = @MobileNo AND SP.name = @plan_name And  p.amount <sp.price
    ORDER BY P.date_of_payment desc
   

    RETURN @remaining_amount;
END;
GO


-- 9. Function: Retrieve Extra Amount for a Certain Plan
CREATE FUNCTION Extra_plan_amount (@MobileNo CHAR(11), @plan_name VARCHAR(50))
RETURNS DECIMAL(10, 1)
AS
BEGIN
    DECLARE @extra_amount DECIMAL(10, 1) = 0;

    SELECT TOP 1 @extra_amount = P.amount - SP.price 
    FROM Service_Plan SP
    join Process_Payment pp on sp.planID = pp.planID
    JOIN Payment P ON pp.paymentID = P.paymentID

    WHERE P.mobileNo = @MobileNo AND SP.name = @plan_name And  p.amount > sp.price
    ORDER BY P.date_of_payment desc

    RETURN @extra_amount;
END;
go



-- 10. Procedure: Retrieve Top 10 Successful Payments
CREATE PROCEDURE Top_Successful_Payments @MobileNo CHAR(11) AS

    SELECT TOP 10 paymentID, amount
    FROM Payment
    WHERE mobileNo = @MobileNo AND status = 'successful'
    ORDER BY amount DESC;

GO

-- 11. Function: Retrieve All Subscribed Plans in the Past 5 Months
CREATE FUNCTION Subscribed_plans_5_Months (@MobileNo CHAR(11))
RETURNS TABLE
AS
RETURN (
    SELECT SP.planID, SP.name, SP.price
    FROM Subscription Sub
    JOIN Service_Plan SP ON Sub.planID = SP.planID
    WHERE Sub.mobileNo = @MobileNo AND Sub.subscription_date >= DATEADD(MONTH, -5, GETDATE())
);
GO


-- 12. Procedure: Initiate Plan Payment and Update Subscription Status
CREATE PROCEDURE Initiate_plan_payment 
@MobileNo CHAR(11), 
@amount DECIMAL(10, 1), 
@payment_method VARCHAR(50), 
@plan_id INT
AS

    -- Insert new payment record
    INSERT INTO Payment (amount, date_of_payment, payment_method, status, mobileNo)
    VALUES (@amount, GETDATE(), @payment_method, 'successful', @MobileNo);

    -- Update subscription status
    UPDATE Subscription
    SET status = 'active'
    WHERE mobileNo = @MobileNo AND planID = @plan_id;

GO

-- 13. Procedure: Calculate Cashback for an Account's Wallet
CREATE PROCEDURE Payment_wallet_cashback 
@MobileNo CHAR(11), 
@payment_id INT, 
@benefit_id INT
AS
BEGIN
    DECLARE @cashback_amount DECIMAL(10, 2);
    
    -- Calculate 10% cashback
    SELECT @cashback_amount = 0.1 * amount
    FROM Payment
    WHERE paymentID = @payment_id AND mobileNo = @MobileNo;
    
    -- Update wallet balance
    UPDATE Wallet
    SET current_balance = current_balance + @cashback_amount
    WHERE mobileNo = @MobileNo;
    
    -- Insert cashback transaction
    INSERT INTO Cashback (benefitID, walletID, amount, credit_date)
    VALUES (@benefit_id, (SELECT walletID FROM Wallet WHERE mobileNo = @MobileNo), @cashback_amount, GETDATE());
END;
GO


-- 14. Procedure: Initiate Balance Payment
CREATE PROCEDURE Initiate_balance_payment 
@MobileNo CHAR(11), 
@amount DECIMAL(10, 1), 
@payment_method VARCHAR(50)
AS
    INSERT INTO Payment (amount, date_of_payment, payment_method, status, mobileNo)
    VALUES (@amount, GETDATE(), @payment_method, 'successful', @MobileNo);
    UPDATE Customer_Customer
    SET balance = balance + @amount
    Where mobileno= @Mobileno;
GO


-- 15. Procedure: Redeem Voucher and Update Account Points
CREATE PROCEDURE Redeem_voucher_points 
@MobileNo CHAR(11), 
@voucher_id INT
AS
BEGIN
    DECLARE @voucher_points INT;
    
    -- Get voucher points
    SELECT @voucher_points = points
    FROM Voucher
    WHERE voucherID = @voucher_id;
    
 
    UPDATE Customer_Account
    SET point = point - @voucher_points
    WHERE mobileNo = @MobileNo;
    
 
    UPDATE Voucher
    SET redeem_date = GETDATE()
    WHERE voucherID = @voucher_id AND mobileNo = @MobileNo;
END;
GO


Create Role admin;
go
GRANT EXECUTE ON Account_Plan TO admin;
GRANT SELECT ON OBJECT::dbo.Account_Plan_date TO admin;
GRANT SELECT ON OBJECT::dbo.Account_Usage_Plan TO admin;
GRANT EXECUTE ON Benefits_Account TO admin;
GRANT SELECT ON OBJECT::dbo.Account_SMS_Offers TO admin;
GRANT EXECUTE ON Account_Payment_Points TO admin;
GRANT REFERENCES ON OBJECT::dbo.Wallet_Cashback_Amount TO admin;
GRANT REFERENCES ON OBJECT::dbo.Wallet_Transfer_Amount TO admin;
GRANT REFERENCES ON OBJECT::dbo.Wallet_MobileNo TO admin;;
GRANT REFERENCES ON OBJECT::dbo.Total_Points_Account TO admin;

GO

CREATE ROLE customer;
GO

-- a) AccountLoginValidation (Scalar Function)
GRANT REFERENCES ON OBJECT::dbo.AccountLoginValidation TO customer;

-- b) Consumption (Table-Valued Function)
GRANT SELECT ON OBJECT::dbo.Consumption TO customer;

-- c) Unsubscribed_Plans (Stored Procedure)
GRANT EXECUTE ON dbo.Unsubscribed_Plans TO customer;

-- d) Usage_Plan_CurrentMonth (Table-Valued Function)
GRANT SELECT ON OBJECT::dbo.Usage_Plan_CurrentMonth TO customer;

-- e) Cashback_Wallet_Customer (Table-Valued Function)
GRANT SELECT ON OBJECT::dbo.Cashback_Wallet_Customer TO customer;

-- f) Ticket_Account_Customer (Stored Procedure)
GRANT EXECUTE ON dbo.Ticket_Account_Customer TO customer;

-- g) Account_Highest_Voucher (Stored Procedure)
GRANT EXECUTE ON dbo.Account_Highest_Voucher TO customer;

-- h) Remaining_plan_amount (Scalar Function)
GRANT REFERENCES ON OBJECT::dbo.Remaining_plan_amount TO customer;

-- i) Extra_plan_amount (Scalar Function)
GRANT REFERENCES ON OBJECT::dbo.Extra_plan_amount TO customer;

-- j) Top_Successful_Payments (Stored Procedure)
GRANT EXECUTE ON dbo.Top_Successful_Payments TO customer;

-- k) Subscribed_plans_5_Months (Table-Valued Function)
GRANT SELECT ON OBJECT::dbo.Subscribed_plans_5_Months TO customer;

-- l) Initiate_plan_payment (Stored Procedure)
GRANT EXECUTE ON dbo.Initiate_plan_payment TO customer;

-- m) Payment_wallet_cashback (Stored Procedure)
GRANT EXECUTE ON dbo.Payment_wallet_cashback TO customer;

-- n) Initiate_balance_payment (Stored Procedure)
GRANT EXECUTE ON dbo.Initiate_balance_payment TO customer;

-- o) Redeem_voucher_points (Stored Procedure)
GRANT EXECUTE ON dbo.Redeem_voucher_points TO customer;
GO




















