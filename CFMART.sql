CREATE TABLE Detail_Order 
    ( 
     Id_Detail_Order  SERIAL  NOT NULL , 
     Quantity         INTEGER  NOT NULL , 
     Catatan          TEXT, 
     Order_Id_Order   INTEGER  NOT NULL , 
     Produk_Id_Produk INTEGER  NOT NULL , 
     Harga_per_item   NUMERIC  NOT NULL 
    ) 
;
sele
ALTER TABLE Detail_Order 
    ADD CONSTRAINT Detail_Order_PK PRIMARY KEY ( Id_Detail_Order ) ;

CREATE TABLE Meja 
    ( 
     Id_Meja    SERIAL  NOT NULL , 
     Nomer_Meja INTEGER  NOT NULL 
    ) 
;

ALTER TABLE Meja 
    ADD CONSTRAINT Meja_PK PRIMARY KEY ( Id_Meja ) ;

CREATE TABLE Metode_Pembayaran 
    ( 
     Id_Metode_Pembayaran SERIAL  NOT NULL , 
     Nama_Metode          VARCHAR (30)  NOT NULL 
    ) 
;

ALTER TABLE Metode_Pembayaran 
    ADD CONSTRAINT Metode_Pembayaran_PK PRIMARY KEY ( Id_Metode_Pembayaran ) ;

CREATE TABLE "Order" 
    ( 
     Id_Order                               SERIAL  NOT NULL , 
     Tgl_Order                              TIMESTAMP DEFAULT CURRENT_TIMESTAMP , 
     User_Id_User                           INTEGER  NOT NULL , 
     Status_Order_Id_Status_Order           INTEGER  NOT NULL , 
     Meja_Id_Meja                           INTEGER  NOT NULL , 
     Tipe_Pesanan_Id_Tipe_Pesanan           INTEGER  NOT NULL , 
     Status_Pembayaran                      BOOLEAN  NOT NULL , 
     Nama_Pelanggan                         VARCHAR (100) ,  
     Metode_Pembayaran_Id_Metode_Pembayaran INTEGER 
    ) 
;
select * from "Order" 
ALTER TABLE "Order" 
    ADD CONSTRAINT Order_PK PRIMARY KEY ( Id_Order ) ;

UPDATE Metode_Pembayaran
SET Nama_Metode = 'QRIS'
WHERE Id_Metode_Pembayaran = 2;

select * from Metode_Pembayaran
CREATE TABLE Produk 
    ( 
     Id_Produk    SERIAL  NOT NULL , 
     Jenis_Produk VARCHAR (100)  NOT NULL , 
     Harga        FLOAT  NOT NULL 
    ) 
;

ALTER TABLE Produk 
    ADD CONSTRAINT Produk_PK PRIMARY KEY ( Id_Produk ) ;

CREATE TABLE Rating_dan_Review ( 
    Id_Rating_dan_Review SERIAL NOT NULL , 
    Rating INT, 
    Review TEXT, 
    Tgl_Rating_dan_Review TIMESTAMP DEFAULT CURRENT_TIMESTAMP, 
    Order_Id_Order INT NOT NULL
);

ALTER TABLE Rating_dan_Review 
    ADD CONSTRAINT Rating_dan_Review_PK PRIMARY KEY ( Id_Rating_dan_Review ) ;

CREATE TABLE "Role"
    ( 
     Id_Role   SERIAL  NOT NULL , 
     Nama_Role VARCHAR (100)  NOT NULL 
    ) 
;

ALTER TABLE "Role"
    ADD CONSTRAINT Role_PK PRIMARY KEY ( Id_Role ) ;

CREATE TABLE Status_Order 
    ( 
     Id_Status_Order SERIAL  NOT NULL , 
     Status_Order    VARCHAR (50)  NOT NULL 
    ) 
;

ALTER TABLE Status_Order 
    ADD CONSTRAINT Status_Order_PK PRIMARY KEY ( Id_Status_Order ) ;

CREATE TABLE Tipe_Pesanan 
    ( 
     Id_Tipe_Pesanan SERIAL  NOT NULL , 
     Tipe_Pesanan    VARCHAR (100)  NOT NULL 
    ) 
;

ALTER TABLE Tipe_Pesanan 
    ADD CONSTRAINT Tipe_Pesanan_PK PRIMARY KEY ( Id_Tipe_Pesanan ) ;

CREATE TABLE "User" 
    ( 
     Id_User      SERIAL  NOT NULL , 
     Username     VARCHAR (100)  NOT NULL , 
     Password_user     VARCHAR (50)  NOT NULL , 
     Role_Id_Role INTEGER  NOT NULL 
    ) 
;
select * from detail_order
select * from "Order"
ALTER TABLE "User" 
    ADD CONSTRAINT User_PK PRIMARY KEY ( Id_User ) ;

ALTER TABLE Detail_Order 
    ADD CONSTRAINT Detail_Order_Order_FK FOREIGN KEY 
    ( 
     Order_Id_Order
    ) 
    REFERENCES "Order" 
    ( 
     Id_Order
    ) 
;
select * from "User"
ALTER TABLE select * from  "User"
ADD COLUMN Status_Karyawan BOOLEAN;
UPDATE "User"
SET Status_Karyawan = TRUE;
ALTER TABLE "User"
ALTER COLUMN Status_Karyawan SET NOT NULL;
DROP TABLE IF EXISTS Rating_dan_Review CASCADE;
ALTER TABLE "Order" DROP COLUMN IF EXISTS Status_Order_Id_Status_Order;
alter table detail_order rename column harga_per_item to sub_total;
update detail_order set sub_total = quantity * sub_total;
CREATE OR REPLACE FUNCTION hitung_sub_total()
RETURNS TRIGGER AS $$
DECLARE
    harga_produk DOUBLE PRECISION;
BEGIN
    -- Ambil harga produk langsung dari tabel Produk berdasarkan ID barang yang dibeli
    SELECT harga INTO harga_produk 
    FROM "Produk" 
    WHERE id_produk = NEW.produk_id_produk;

    -- Hitung sub_total yang murni dan mutlak
    NEW.sub_total := NEW.quantity * harga_produk;
    
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

CREATE or replace TRIGGER trg_hitung_sub_total
BEFORE INSERT OR UPDATE ON detail_order
FOR EACH ROW
EXECUTE FUNCTION hitung_sub_total();
alter table detail_order alter column sub_total set not null;
ALTER TABLE Detail_Order 
    ADD CONSTRAINT Detail_Order_Produk_FK FOREIGN KEY 
    ( 
     Produk_Id_Produk
    ) 
    REFERENCES Produk 
    ( 
     Id_Produk
    ) 
;
select * from detail_order
ALTER TABLE "Order" 
    ADD CONSTRAINT Order_Meja_FK FOREIGN KEY 
    ( 
     Meja_Id_Meja
    ) 
    REFERENCES Meja 
    ( 
     Id_Meja
    ) 
;

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_Metode_Pembayaran_FK FOREIGN KEY 
    ( 
     Metode_Pembayaran_Id_Metode_Pembayaran
    ) 
    REFERENCES Metode_Pembayaran 
    ( 
     Id_Metode_Pembayaran
    ) 
;

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_Status_Order_FK FOREIGN KEY 
    ( 
     Status_Order_Id_Status_Order
    ) 
    REFERENCES Status_Order 
    ( 
     Id_Status_Order
    ) 
;

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_Tipe_Pesanan_FK FOREIGN KEY 
    ( 
     Tipe_Pesanan_Id_Tipe_Pesanan
    ) 
    REFERENCES Tipe_Pesanan 
    ( 
     Id_Tipe_Pesanan
    ) 
;

ALTER TABLE "Order" 
    ADD CONSTRAINT Order_User_FK FOREIGN KEY 
    ( 
     User_Id_User
    ) 
    REFERENCES "User" 
    ( 
     Id_User
    ) 
;
ALTER TABLE "Order"
ADD COLUMN Nama_Lengka VARCHAR(15);

ALTER TABLE Rating_dan_Review 
    ADD CONSTRAINT Rating_dan_Review_Order_FK FOREIGN KEY 
    ( 
     Order_Id_Order
    ) 
    REFERENCES "Order" 
    ( 
     Id_Order
    ) 
;

ALTER TABLE "User" 
    ADD CONSTRAINT User_Role_FK FOREIGN KEY 
    ( 
     Role_Id_Role
    ) 
    REFERENCES "Role" 
    ( 
     Id_Role
    ) 
;

ALTER TABLE Produk 
    ADD COLUMN Stok INTEGER NOT NULL DEFAULT 0,
    ADD COLUMN Foto_Produk BYTEA;

-- 1. Tabel Role
INSERT INTO "Role" (Nama_Role) VALUES 
('Admin'),
('Kasir'),
('Pelanggan');

-- 2. Tabel Meja
INSERT INTO Meja (Nomer_Meja) VALUES 
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10),
(11),
(12),
(13),
(14),
(15);
ALTER TABLE "Order" ALTER COLUMN Meja_Id_Meja DROP NOT NULL;
UPDATE "Order" 
SET meja_id_meja = NULL, 
    nama_pelanggan = 'Reno' 
WHERE id_order = 3;

-- 3. Tabel Metode_Pembayaran
INSERT INTO Metode_Pembayaran (Nama_Metode) VALUES 
('Tunai'),
('Non Tunai');


-- 4. Tabel Status_Order
INSERT INTO Status_Order (Status_Order) VALUES 
('Memasak'),
('Selesai'),
('Dalam Antrian');


-- 5. Tabel Tipe_Pesanan
INSERT INTO Tipe_Pesanan (Tipe_Pesanan) VALUES 
('Dine In'),
('Take Away');


-- 6. Tabel Produk
INSERT INTO Produk (Jenis_Produk, Harga) VALUES 
('Lele Bakar', 18000 ),
('Lele Goreng', 12000 ),
('Mangut Lele', 22000),
('Es Teh', 3000, ),
('Es Jeruk', 4000),
('Air Mineral', 3500);
update Produk
set stok = 20
where id_produk = 6;
--update foto
-- Menggunakan UPDATE (karena datamu sudah terlanjur di-insert)
UPDATE Produk 
SET foto_produk = pg_read_binary_file('C:/tmp/lele_bakar.jpg') -- sesuaikan path gambarmu
WHERE id_produk = 1;



-- 7. Tabel User ( Id_Role: 1 = Admin, 2 = Kasir)
INSERT INTO "User" (Username, Password_user, Role_Id_Role) VALUES 
('Harley', 'admin123', 1),
('Sari', 'kasir123', 2);
TRUNCATE TABLE "User" RESTART IDENTITY CASCADE;


-- 8. Tabel Order
-- Catatan: Status_Pembayaran diisi true (sudah bayar) atau false (belum bayar)
INSERT INTO "Order" (User_Id_User, Status_Order_Id_Status_Order, Meja_Id_Meja, Tipe_Pesanan_Id_Tipe_Pesanan, Status_Pembayaran, Nama_Pelanggan, Metode_Pembayaran_Id_Metode_Pembayaran) VALUES 
(2, 2, 1, 1, true, 'Andi Wijaya', 2), -- User Siti, Selesai, Meja 1, Dine In, Lunas, QRIS
(2, 1, 3, 1, false, 'Citra Lestari', 1), -- User Siti, Memasak, Meja 3, Dine In, Belum Lunas, Tunai
(2, 2, 2, 2, true, 'Reno', 1); -- User Siti, Selesai, Meja 2, Take Away, Lunas, Debit
UPDATE "Order"
SET Nomor_Pelanggan =
    CASE
        WHEN id_order = 1 THEN '081234567890'
        WHEN id_order = 2 THEN '082345678901'
        WHEN id_order = 3 THEN '083456789012'
    END;
ALTER TABLE "Order"
ALTER COLUMN Nomor_Pelanggan SET NOT NULL;
-- Mengubah kolom Nomor_Pelanggan agar boleh kosong (NULL)
ALTER TABLE "Order" 
ALTER COLUMN Nomor_Pelanggan DROP NOT NULL;


-- 9. Tabel Detail_Order
-- Menghubungkan ID Order dengan Produk yang dibeli
INSERT INTO Detail_Order (Quantity, Catatan, Order_Id_Order, Produk_Id_Produk, Harga_per_item) VALUES 
(2, 'Pedas sedang ya', 1, 1, 18000), -- Order #1 beli 2 Lele Bakar
(1, 'Gulanya sedikit', 1, 4, 3000),   -- Order #1 beli 1 Es Teh
(1, 'Tanpa sayur', 2, 2, 12000),             -- Order #2 beli 1 Lele Goreng
(2, 'Es batunya sedikit aja', 3, 5, 4000);     -- Order #3 beli 2 Es Jeruk


-- 10. Tabel Rating_dan_Review
INSERT INTO Rating_dan_Review (Rating, Review, Order_Id_Order) VALUES 
(5, 'Makanannya enak, pegawainya ramah banget', 1),
(4, 'Pelayanan oke, tapi Es batunya kebanyakan.', 3);


select * from "Role"
select * from Meja
select * from Metode_Pembayaran
select * from Status_Order
select * from Tipe_Pesanan
select * from Produk
select * from "User"
select * from "Order"
select * from Detail_Order
select * from Rating_dan_Review
select * from v_nota_pembayaran

--view 
-- 1. Hapus VIEW lama
DROP VIEW v_nota_pembayaran;

-- 2. Buat VIEW baru yang bersih
CREATE VIEW v_nota_pembayaran AS
SELECT 
    o.id_order,
    o.tgl_order,
    -- LOGIKA NOTA BERSIH:
    -- Kalau meja ada isinya -> Tampilkan Nomor Meja (Dine In)
    -- Kalau meja KOSONG (NULL) -> Tampilkan Nama Pelanggan (Take Away)
    CASE 
        WHEN o.meja_id_meja IS NOT NULL THEN CONCAT('Meja No. ', m.nomer_meja)
        ELSE o.nama_pelanggan 
    END AS identitas_pelanggan,
    
    o.nomor_pelanggan AS no_hp_pelanggan, 
    p.jenis_produk, 
    od.quantity,
    od.harga_per_item,
    (od.quantity * od.harga_per_item) AS subtotal,
    u.username AS kasir_yang_melayani
FROM "Order" o
LEFT JOIN meja m ON o.meja_id_meja = m.id_meja   -- Pakai LEFT JOIN lagi karena meja Reno sudah NULL
JOIN "User" u ON o.user_id_user = u.id_user         
JOIN detail_order od ON o.id_order = od.order_id_order
JOIN produk p ON od.produk_id_produk = p.id_produk;

--teori himpunan

SELECT id_produk, jenis_produk, harga, string_agg(kategori_produk, ', ') AS kategori_produk
FROM (
    -- Query Utama kita bungkus di dalam subquery
    SELECT p.id_produk, p.jenis_produk, p.harga, 'Terlaris' AS kategori_produk
    FROM produk p
    JOIN detail_order od ON p.id_produk = od.produk_id_produk
    WHERE od.quantity > 1

    UNION ALL -- Pakai UNION ALL agar semua label ketampung dulu

    SELECT p.id_produk, p.jenis_produk, p.harga, 'Rating Tertinggi' AS kategori_produk
    FROM produk p
    JOIN detail_order od ON p.id_produk = od.produk_id_produk
    JOIN rating_dan_review r ON od.order_id_order = r.order_id_order
    WHERE r.rating = 5
) AS data_gabungan
GROUP BY id_produk, jenis_produk, harga;

-- 1. Ambil semua produk yang PERNAH DIBELI oleh pelanggan
SELECT p.id_produk, p.jenis_produk, p.harga
FROM produk p
JOIN detail_order od ON p.id_produk = od.produk_id_produk

EXCEPT

-- 2. Ambil semua produk yang SUDAH PERNAH DICENTANG/DIBERI REVIEW
SELECT p.id_produk, p.jenis_produk, p.harga
FROM produk p
JOIN detail_order od ON p.id_produk = od.produk_id_produk
JOIN rating_dan_review r ON od.order_id_order = r.order_id_order;

--subquery 
SELECT id_produk, jenis_produk, harga
FROM produk
WHERE harga < (
    -- Ini adalah SUBQUERY-nya (Query di dalam query)
    SELECT AVG(harga) FROM produk
);

-- =========================================================================
-- C.2. SUBQUERY: Mencari Produk Berdasarkan Riwayat Transaksi Tertentu (Quantity >= 2)
-- =========================================================================
SELECT id_produk, jenis_produk, harga
FROM produk
WHERE id_produk IN (
    -- Subquery mencari id_produk yang pernah dipesan melimpah dalam satu orderan
    SELECT produk_id_produk 
    FROM detail_order 
    WHERE quantity >= 2
);

--subquery
-- =========================================================================
-- SCALAR SUBQUERY: Menampilkan produk di bawah rata-rata harga toko
-- =========================================================================
SELECT id_produk, jenis_produk, harga
FROM produk
WHERE harga < (
    -- Subquery menghasilkan 1 nilai scalar (nilai rata-rata harga)
    SELECT AVG(harga) FROM produk
);

-- =========================================================================
-- C.2. CORRELATED SUBQUERY: Melihat berapa kali setiap produk pernah diorder
-- =========================================================================
SELECT p.id_produk, p.jenis_produk,
       (SELECT COALESCE(SUM(od.quantity), 0)
        FROM detail_order od
        WHERE od.produk_id_produk = p.id_produk) AS total_kali_dipesan
FROM produk p;


--statement 
DO $$
DECLARE
    -- Deklarasi variabel sesuai kolom di tabel Produk kamu
    v_id_produk INTEGER := 4;       -- Contoh mengecek Air Mineral (ID 6) yang stoknya ada 20
    v_nama_produk VARCHAR(100);
    v_stok_produk INTEGER;
BEGIN
    -- Ambil data produk berdasarkan ID dari tabel Produk asli milikmu
    SELECT jenis_produk, stok
    INTO v_nama_produk, v_stok_produk
    FROM produk
    WHERE id_produk = v_id_produk;

    -- Logika IF Statement sesuai prasyarat khusus (Business Rule)
    IF v_stok_produk = 0 THEN
        RAISE NOTICE 'Peringatan: Menu "%" sedang HABIS! Kasir jangan menerima pesanan.', v_nama_produk;
    ELSE
        RAISE NOTICE 'Menu "%" SIAP DIORDER. Stok tersisa % porsi/botol.', v_nama_produk, v_stok_produk;
    END IF;
END $$;


--function total harga
CREATE OR REPLACE FUNCTION Total_Harga_Pesanan (id_order INT)
RETURNS NUMERIC AS $$
DECLARE
    v_total_harga NUMERIC := 0;
BEGIN
    -- Mengubah nama tabel dan kolom menjadi huruf kecil tanpa petik ganda
    SELECT COALESCE(SUM(quantity * harga_per_item), 0)
    INTO v_total_harga
    FROM detail_order
    WHERE order_id_order = id_order;

    RETURN v_total_harga;
END;
$$ LANGUAGE plpgsql;

SELECT Total_Harga_Pesanan(2) -- Ganti angka 1 dengan Id_Order yang ada di databasemu

--store procedure checkout
CREATE OR REPLACE PROCEDURE sp_Check_Out_Pesanan(
    p_user_id INT,
    p_status_order_id INT,
    p_meja_id INT,
    p_tipe_pesanan_id INT,
    p_metode_pembayaran_id INT, -- Berdasarkan pola tabelmu, kita tambahkan parameter ID ini
    p_nama_pelanggan VARCHAR,
    p_nomor_pelanggan VARCHAR,
    p_produk_id INT,
    p_quantity INT,
    p_catatan VARCHAR
) AS $$
DECLARE
    v_new_order_id INT;
    v_harga_produk NUMERIC;
BEGIN
    -- 1. Ambil harga produk dari tabel produk untuk dikunci di detail order
    -- (Disarankan menggunakan huruf kecil semua: 'produk' & 'id_produk' agar tidak error)
    SELECT harga INTO v_harga_produk 
    FROM produk 
    WHERE id_produk = p_produk_id;

    -- Validasi jika produk tidak ditemukan
    IF v_harga_produk IS NULL THEN
        RAISE EXCEPTION 'Produk dengan ID % tidak ditemukan!', p_produk_id;
    END IF;

    -- 2. Insert data utama ke tabel Order
    INSERT INTO "Order" (
        tgl_order, 
        user_id_user, 
        status_order_id_status_order, 
        meja_id_meja, 
        tipe_pesanan_id_tipe_pesanan,
        metode_pembayaran_id_metode_pembayaran, -- Kolom baru untuk metode pembayaran (sesuaikan dengan nama kolom aslimu)
        status_pembayaran, 
        nama_pelanggan, 
        nomor_pelanggan
    ) VALUES (
        CURRENT_TIMESTAMP, 
        p_user_id, 
        p_status_order_id, 
        p_meja_id, 
        p_tipe_pesanan_id, 
        p_metode_pembayaran_id, -- Mengisi data metode pembayaran dari parameter
        '0', -- '0' berarti belum lunas / pending
        p_nama_pelanggan, 
        p_nomor_pelanggan
    ) RETURNING id_order INTO v_new_order_id;

    -- 3. Insert rincian barang ke tabel Detail_Order
    -- (Disarankan menggunakan huruf kecil semua: 'detail_order')
    INSERT INTO detail_order (
        quantity, 
        catatan, 
        order_id_order, 
        produk_id_produk, 
        harga_per_item
    ) VALUES (
        p_quantity, 
        p_catatan, 
        v_new_order_id, 
        p_produk_id, 
        v_harga_produk
    );
    
    COMMIT;
END;
$$ LANGUAGE plpgsql;

select * from "Order"
select * from Detail_Order
select * from Produk
CALL sp_Check_Out_Pesanan(
    2,                  -- p_user_id (ID Kasir yang melayani, misal ID 1)
    3,                  -- p_status_order_id (Misal ID 1 = 'Pending')
    4,                  -- p_meja_id (Misal ID 1 = Meja Nomor 10)
    1,                  -- p_tipe_pesanan_id (Misal ID 1 = 'Dine In')
	2,          -- p_metode_pembayaran_id (QRIS/Cash sesuai master datamu)
    'laili',      -- p_nama_pelanggan
    '0812345678',       -- p_nomor_telepon
    5,                  -- p_produk_id (ID makanan/minuman yang dibeli, misal ID 5)
    3,                  -- p_quantity (Jumlah beli, misal 3 porsi)
    'Satu dibungkus'  -- p_catatan tambahan
);

--potong stok
-- A. Buat Fungsi Trigger
CREATE OR REPLACE FUNCTION fn_Potong_Stok()
RETURNS TRIGGER AS $$
BEGIN
    -- Ubah "Produk" menjadi produk (huruf kecil, tanpa kutip)
    UPDATE produk
    SET stok = stok - NEW.quantity -- pastikan nama kolom stok & quantity juga sesuai
    WHERE id_produk = NEW.produk_id_produk;
    
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- B. Pasang Trigger ke Tabel Detail_Order
CREATE OR REPLACE TRIGGER tg_after_insert_detail_order
AFTER INSERT ON Detail_Order
FOR EACH ROW
EXECUTE FUNCTION fn_Potong_Stok();

--hapus produk
-- A. Buat Fungsi Trigger
CREATE OR REPLACE FUNCTION fn_Hapus_Data_Produk()
RETURNS TRIGGER AS $$
BEGIN
    IF EXISTS (SELECT 1 FROM Detail_Order WHERE Produk_Id_Produk = OLD.Id_Produk) THEN
        RAISE EXCEPTION 'Produk tidak bisa dihapus karena memiliki riwayat transaksi di Detail_Order!';
    END IF;
    RETURN OLD;
END;
$$ LANGUAGE plpgsql;

-- B. Pasang Trigger ke Tabel Produk
CREATE OR REPLACE TRIGGER tg_Hapus_Data_Produk
BEFORE DELETE ON Produk
FOR EACH ROW
EXECUTE FUNCTION fn_Hapus_Data_Produk();

--upsert data karyawan
CREATE OR REPLACE PROCEDURE sp_Upsert_Karyawan(
    p_id_user INT,          -- Isi NULL untuk karyawan baru, isi ANGKA ID untuk edit karyawan lama
    p_username VARCHAR,     -- Bisa diubah / diisi NULL jika tidak ingin diubah
    p_password VARCHAR,     -- Bisa diubah / diisi NULL jika tidak ingin diubah
    p_role_id INT,          -- Bisa diubah / diisi NULL jika tidak ingin diubah
    p_status_karyawan BOOLEAN  -- Bisa diubah / diisi NULL jika tidak ingin diubah
) AS $$
BEGIN
    -- 1. Logika EDIT / UPDATE (Jika p_id_user diisi angka dan datanya eksis)
    IF p_id_user IS NOT NULL AND EXISTS (SELECT 1 FROM "User" WHERE id_user = p_id_user) THEN
        UPDATE "User"
        SET 
            Username = COALESCE(p_username, Username),
            Password_user = COALESCE(p_password, Password_user),
            Role_Id_Role = COALESCE(p_role_id, Role_Id_Role),
            Status_Karyawan = COALESCE(p_status_karyawan, Status_Karyawan)
        WHERE id_user = p_id_user;
        
    -- 2. Logika TAMBAH / INSERT (Jika p_id_user bernilai NULL)
    ELSE
        -- Validasi wajib: Untuk karyawan baru, username & password tidak boleh kosong
        IF p_username IS NULL OR p_password IS NULL THEN
            RAISE EXCEPTION 'Untuk karyawan baru, Username dan Password wajib diisi!';
        END IF;

        INSERT INTO "User" (Username, Password_user, Role_Id_Role, Status_Karyawan)
        VALUES (
            p_username, 
            p_password, 
            COALESCE(p_role_id, 1),           -- Jika role null, otomatis jadi Kasir (ID: 1)
            COALESCE(p_status_karyawan, '1')  -- Jika status null, otomatis Aktif ('1')
        );
    END IF;
    
    COMMIT;
END;
$$ LANGUAGE plpgsql;

select *from "User"
-- KENA 1: Tes INSERT
CALL sp_Upsert_Karyawan(NULL::INT, 'laili_kasir', 'password123', 2, true);

-- Cek apakah masuk:
SELECT * FROM "User" WHERE Username = 'laili_kasir';

-- KENA 2: Tes UPDATE (Mengubah username dari data ID: 88 yang sama)
CALL sp_Upsert_Karyawan(3, 'Rosa', 'password123', 2, true);

-- Cek apakah terupdate:
SELECT * FROM "User" WHERE Username = 'Rosa';

--tes trigger
SELECT id_produk, stok AS stok_awal 
FROM produk 
WHERE id_produk = 1;

-- Kita coba beli 2 pcs
CALL sp_Check_Out_Pesanan(
    1,          -- p_user_id (Pastikan ID ini ada di tabel User)
    1,          -- p_status_order_id
    1,          -- p_meja_id
    1,          -- p_tipe_pesanan_id
    1,          -- p_metode_pembayaran_id
    'Pelanggan Tes', -- p_nama_pelanggan
    '0812345',  -- p_nomor_pelanggan
    1,          -- p_produk_id (Produk yang mau dites)
    2,          -- p_quantity (Beli 2 pcs untuk tes potong stok)
    'Tes Trigger via SP' -- p_catatan
);

SELECT id_produk, stok AS stok_akhir 
FROM produk 
WHERE id_produk = 1;

DELETE FROM detail_order 
WHERE order_id_order IN (
    SELECT id_order FROM "Order" WHERE nama_pelanggan = 'Pelanggan Tes'
);

DELETE FROM "Order" 
WHERE nama_pelanggan = 'Pelanggan Tes';

UPDATE produk 
SET stok = stok + 2 
WHERE id_produk = 1; -- Sesuaikan ID produknya jika kemarin kamu tes pakai produk lain

SELECT setval(pg_get_serial_sequence('"Order"', 'id_order'), COALESCE(MAX(id_order), 0) + 1, false) FROM "Order";

DELETE FROM Produk WHERE id_produk = 1;

--Transaction
--KONFIRMASI PEMBAYARAN--
BEGIN;

UPDATE "Order"
SET
    Status_Pembayaran = TRUE,
    Status_Order_Id_Status_Order = 2,
    Metode_Pembayaran_Id_Metode_Pembayaran = 1
WHERE Id_Order = 1;

COMMIT;

--Group by
--RINGKASAN PENJUALAN--
--Ringkasan Penjualan Harian--
SELECT
    DATE(Tgl_Order) AS Tanggal,
    COUNT(Id_Order) AS Jumlah_Transaksi
FROM "Order"
GROUP BY DATE(Tgl_Order)
ORDER BY Tanggal;

--Ringkasan Pendapatan Harian--
SELECT
    DATE(o.Tgl_Order) AS Tanggal,
    SUM(d.Quantity * d.Harga_per_item) AS Total_Pendapatan
FROM "Order" o
JOIN Detail_Order d
    ON o.Id_Order = d.Order_Id_Order
GROUP BY DATE(o.Tgl_Order)
ORDER BY Tanggal;

SELECT
    mp.Nama_Metode,
    COUNT(o.Id_Order) AS Jumlah_Transaksi,
    SUM(d.Quantity * d.Harga_per_item) AS Total_Pendapatan
FROM "Order" o
JOIN Detail_Order d
    ON o.Id_Order = d.Order_Id_Order
JOIN Metode_Pembayaran mp
    ON mp.Id_Metode_Pembayaran =
       o.Metode_Pembayaran_Id_Metode_Pembayaran
GROUP BY mp.Nama_Metode;

--Ringkasan berdasarkan metode pembayaran--
SELECT
    mp.Nama_Metode,
    COUNT(o.Id_Order) AS Jumlah_Transaksi,
    SUM(d.Quantity * d.Harga_per_item) AS Total_Pendapatan
FROM "Order" o
JOIN Detail_Order d
    ON o.Id_Order = d.Order_Id_Order
JOIN Metode_Pembayaran mp
    ON mp.Id_Metode_Pembayaran =
       o.Metode_Pembayaran_Id_Metode_Pembayaran
GROUP BY mp.Nama_Metode;

--Rollup
--Laporan Produk Terjual per Tanggal
SELECT
    DATE(o.Tgl_Order) AS Tanggal_Order,
    p.Jenis_Produk,
    SUM(d.Quantity) AS Total_Terjual
FROM Detail_Order d
JOIN Produk p
    ON d.Produk_Id_Produk = p.Id_Produk
JOIN "Order" o
    ON d.Order_Id_Order = o.Id_Order
GROUP BY ROLLUP
(
    DATE(o.Tgl_Order),
    p.Jenis_Produk
)
ORDER BY DATE(o.Tgl_Order), p.Jenis_Produk;

--Cube
--Pendapatan berdasarkan tipe pesanan dan metode pembayaran--
SELECT
    tp.Tipe_Pesanan,
    mp.Nama_Metode,
    SUM(d.Quantity * d.Harga_per_item) AS Total_Pendapatan
FROM "Order" o
JOIN Detail_Order d
    ON o.Id_Order = d.Order_Id_Order
JOIN Tipe_Pesanan tp
    ON tp.Id_Tipe_Pesanan =
       o.Tipe_Pesanan_Id_Tipe_Pesanan
JOIN Metode_Pembayaran mp
    ON mp.Id_Metode_Pembayaran =
       o.Metode_Pembayaran_Id_Metode_Pembayaran
GROUP BY CUBE
(
    tp.Tipe_Pesanan,
    mp.Nama_Metode
);

--Grouping sets
--Laporan Keuangan Berdasarkan Tanggal, Produk, dan Metode Pembayaran--
SELECT
    DATE(o.Tgl_Order) AS Tanggal_Order,
    p.Jenis_Produk,
    mp.Nama_Metode,
    SUM(d.Quantity * d.Harga_per_item) AS Total_Pendapatan
FROM Detail_Order d
JOIN Produk p
    ON d.Produk_Id_Produk = p.Id_Produk
JOIN "Order" o
    ON d.Order_Id_Order = o.Id_Order
JOIN Metode_Pembayaran mp
    ON o.Metode_Pembayaran_Id_Metode_Pembayaran =
       mp.Id_Metode_Pembayaran
GROUP BY GROUPING SETS
(
    (DATE(o.Tgl_Order)),
    (DATE(o.Tgl_Order), p.Jenis_Produk),
    (DATE(o.Tgl_Order), mp.Nama_Metode),
    ()
)
ORDER BY Tanggal_Order;

SELECT id_produk, jenis_produk, foto_produk FROM produk;

SELECT table_name FROM information_schema.tables WHERE table_schema = 'public';

select * from detail_order

SELECT pg_get_triggerdef(oid) 
FROM pg_trigger 
WHERE tgname LIKE '%sub_total%' OR tgname LIKE '%hitung%';

CREATE OR REPLACE FUNCTION hitung_sub_total()
RETURNS TRIGGER AS $$
DECLARE
    v_harga NUMERIC;
BEGIN
    SELECT harga 
    INTO v_harga
    FROM produk
    WHERE id_produk = NEW.produk_id_produk;
    
    NEW.sub_total := v_harga * NEW.quantity;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

select * from detail_order

SELECT p.jenis_produk 
FROM detail_order d
JOIN produk p ON d.produk_id_produk = p.id_produk
JOIN "Order" o ON d.order_id_order = o.id_order
WHERE DATE(o.tgl_order) = CURRENT_DATE
GROUP BY p.jenis_produk 
ORDER BY SUM(d.quantity) DESC 
LIMIT 1;

SELECT event_object_table, trigger_name, action_statement 
FROM information_schema.triggers;
DROP TRIGGER tg_after_insert_detail_order ON detail_order;