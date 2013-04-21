<?php

/**
 * Return the n-th prime
 *
 * @param integer $n Prime to find
 *
 * @return integer
 */
function getNthPrime ($n) {

    $i      = 2;
    $primes = array($i);

    for (; count($primes) !== $n; ++$i) {

        $composite = false;
        $sqrt      = sqrt($i);

        foreach ($primes as $prime) {

            if ($prime > $sqrt) {
                break;
            }

            if ($i % $prime === 0) {
                $composite = true;
                break;
            }
        }

        if (!$composite) {
            $primes[] = $i;
        }
    }

    return $primes[$n - 1];
}

echo sprintf("10001th prime: %s\n", getNthPrime(10001));
