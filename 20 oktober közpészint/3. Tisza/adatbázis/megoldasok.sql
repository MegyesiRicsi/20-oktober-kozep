-- A feladatok megoldására elkészített SQL parancsokat illessze be a feladat sorszáma után!

-- 10. feladat:

CREATE DATABASE tizsa DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
-- 12. feladat:
DELETE from meres WHERE nap="2020.03.27"

-- 13. feladat:
UPDATE vizmerce set igId=2 WHERE varos="tokaj"


-- 14. feladat:
SELECT varos, nullPont from vizmerce order by nullPont limit 1;

-- 15. feladat:
SELECT varos, (lnv-lkv) ingadozas from vizmerce ORDER by lnv-lkv DEsc
 
-- 16. feladat:

SELECT igazgatosag.nev, COUNT(vizmerce.id) AS merceszam FROM igazgatosag INNER JOIN vizmerce ON vizmerce.igId=igazgatosag.id GROUP BY igazgatosag.nev;
-- 17. feladat:

SELECT AVG(meres.vizAllas) from vizmerce INNER JOIN meres on vizmerce.id=meres.vmId WHERE vizmerce.varos="Szolnok" and meres.nap LIKE "2020-04%"