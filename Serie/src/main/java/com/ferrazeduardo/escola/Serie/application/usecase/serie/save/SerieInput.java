package com.ferrazeduardo.escola.Serie.application.usecase.serie.save;

import java.math.BigDecimal;
import java.text.DecimalFormat;
import java.util.Date;
import java.util.UUID;

public record SerieInput(
    int ano,
    int quantidadeAvalicao,
    UUID id_rede,
    BigDecimal valorMedia,
    Date dataInicio,
    Date DataFim
) {
}
