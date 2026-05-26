const CAPACITY_TABLE = [
  { largo: 1.83, ancho: 1.83, alto: 2.4, volumen: 8.037, enfriamientoHP: "3/4", enfriamientoBTU: 6500, congelacionHP: "1.5", congelacionBTU: 6500 },
  { largo: 1.83, ancho: 2.4, alto: 2.4, volumen: 10.541, enfriamientoHP: "1", enfriamientoBTU: 9000, congelacionHP: "1.5", congelacionBTU: 6500 },
  { largo: 1.83, ancho: 3, alto: 2.4, volumen: 13.176, enfriamientoHP: "1", enfriamientoBTU: 9000, congelacionHP: "2", congelacionBTU: 9000 },
  { largo: 2.4, ancho: 2.4, alto: 2.4, volumen: 13.824, enfriamientoHP: "1", enfriamientoBTU: 9000, congelacionHP: "2", congelacionBTU: 9000 },
  { largo: 2.4, ancho: 3, alto: 2.4, volumen: 17.28, enfriamientoHP: "1", enfriamientoBTU: 10400, congelacionHP: "2", congelacionBTU: 9000 },
  { largo: 2.4, ancho: 3.65, alto: 2.4, volumen: 21.024, enfriamientoHP: "1.5", enfriamientoBTU: 13000, congelacionHP: "2", congelacionBTU: 9000 },
  { largo: 3, ancho: 3, alto: 3, volumen: 27, enfriamientoHP: "1.5", enfriamientoBTU: 13000, congelacionHP: "3", congelacionBTU: 12000 },
  { largo: 2.4, ancho: 4.26, alto: 3, volumen: 30.672, enfriamientoHP: "1.5", enfriamientoBTU: 13000, congelacionHP: "3", congelacionBTU: 12000 },
  { largo: 3, ancho: 3.65, alto: 3, volumen: 32.85, enfriamientoHP: "1.5", enfriamientoBTU: 14000, congelacionHP: "3", congelacionBTU: 12000 },
  { largo: 2.4, ancho: 4.87, alto: 3, volumen: 35.064, enfriamientoHP: "2", enfriamientoBTU: 13000, congelacionHP: "3", congelacionBTU: 12000 },
  { largo: 3, ancho: 4.26, alto: 3, volumen: 38.34, enfriamientoHP: "2", enfriamientoBTU: 15600, congelacionHP: "3", congelacionBTU: 12000 },
  { largo: 2.4, ancho: 5.48, alto: 3, volumen: 39.456, enfriamientoHP: "2", enfriamientoBTU: 14000, congelacionHP: "3", congelacionBTU: 12000 },
  { largo: 3.65, ancho: 3.65, alto: 3, volumen: 39.968, enfriamientoHP: "2", enfriamientoBTU: 15600, congelacionHP: "3", congelacionBTU: 12000 },
  { largo: 2.4, ancho: 6, alto: 3, volumen: 43.2, enfriamientoHP: "2", enfriamientoBTU: 15600, congelacionHP: "4", congelacionBTU: 18000 },
  { largo: 3, ancho: 4.87, alto: 3, volumen: 43.83, enfriamientoHP: "2", enfriamientoBTU: 15600, congelacionHP: "4", congelacionBTU: 18000 },
  { largo: 3.65, ancho: 4.26, alto: 3, volumen: 46.647, enfriamientoHP: "2", enfriamientoBTU: 15600, congelacionHP: "4", congelacionBTU: 14000 },
  { largo: 2.4, ancho: 6.7, alto: 3, volumen: 48.24, enfriamientoHP: "2", enfriamientoBTU: 18000, congelacionHP: "4", congelacionBTU: 18000 },
  { largo: 3, ancho: 5.48, alto: 3, volumen: 49.32, enfriamientoHP: "2", enfriamientoBTU: 18000, congelacionHP: "4", congelacionBTU: 18000 },
  { largo: 2.4, ancho: 7.31, alto: 3, volumen: 52.632, enfriamientoHP: "2", enfriamientoBTU: 18000, congelacionHP: "4", congelacionBTU: 18000 },
  { largo: 3.65, ancho: 4.87, alto: 3, volumen: 53.327, enfriamientoHP: "2", enfriamientoBTU: 18000, congelacionHP: "4", congelacionBTU: 14000 },
  { largo: 3, ancho: 6, alto: 3, volumen: 54, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "4", congelacionBTU: 18000 },
  { largo: 4.26, ancho: 4.26, alto: 3, volumen: 54.443, enfriamientoHP: "2", enfriamientoBTU: 20800, congelacionHP: "5", congelacionBTU: 16000 },
  { largo: 2.4, ancho: 7.92, alto: 3, volumen: 57.024, enfriamientoHP: "3", enfriamientoBTU: 20800, congelacionHP: "5", congelacionBTU: 24000 },
  { largo: 3.65, ancho: 5.48, alto: 3, volumen: 60.006, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "5", congelacionBTU: 16000 },
  { largo: 2.4, ancho: 8.53, alto: 3, volumen: 61.416, enfriamientoHP: "3", enfriamientoBTU: 20800, congelacionHP: "5", congelacionBTU: 18000 },
  { largo: 4.26, ancho: 4.87, alto: 3, volumen: 62.239, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "5", congelacionBTU: 16000 },
  { largo: 3.65, ancho: 6, alto: 3, volumen: 65.7, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "5", congelacionBTU: 16000 },
  { largo: 3, ancho: 7.31, alto: 3, volumen: 65.79, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "4", congelacionBTU: 18000 },
  { largo: 2.4, ancho: 9.14, alto: 3, volumen: 65.808, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "6", congelacionBTU: 24000 },
  { largo: 2.4, ancho: 9.75, alto: 3, volumen: 70.2, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "6", congelacionBTU: 24000 },
  { largo: 4.87, ancho: 4.87, alto: 3, volumen: 71.151, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "5", congelacionBTU: 16000 },
  { largo: 3.65, ancho: 6.7, alto: 3, volumen: 73.365, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "6", congelacionBTU: 24000 },
  { largo: 4.26, ancho: 6, alto: 3, volumen: 76.68, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "6", congelacionBTU: 18000 },
  { largo: 3, ancho: 8.53, alto: 3, volumen: 76.77, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "6", congelacionBTU: 24000 },
  { largo: 4.87, ancho: 6, alto: 3, volumen: 87.66, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "6", congelacionBTU: 20000 },
  { largo: 5.48, ancho: 5.48, alto: 3, volumen: 90.091, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "6", congelacionBTU: 20000 },
  { largo: 4.26, ancho: 7.31, alto: 3, volumen: 93.422, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "6", congelacionBTU: 24000 },
  { largo: 5.48, ancho: 6, alto: 3, volumen: 98.64, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "6", congelacionBTU: 24000 },
  { largo: 4.87, ancho: 7.31, alto: 3, volumen: 106.799, enfriamientoHP: "3", enfriamientoBTU: 26000, congelacionHP: "7.5", congelacionBTU: 28000 },
  { largo: 6, ancho: 6, alto: 3, volumen: 108, enfriamientoHP: "4", enfriamientoBTU: 31200, congelacionHP: "7.5", congelacionBTU: 28000 },
  { largo: 5.48, ancho: 7.31, alto: 3, volumen: 120.176, enfriamientoHP: "4", enfriamientoBTU: 31200, congelacionHP: "7.5", congelacionBTU: 28000 },
  { largo: 6, ancho: 7.31, alto: 3, volumen: 131.58, enfriamientoHP: "4", enfriamientoBTU: 37000, congelacionHP: "7.5", congelacionBTU: 24000 },
  { largo: 6, ancho: 8.53, alto: 3, volumen: 153.54, enfriamientoHP: "4", enfriamientoBTU: 36000, congelacionHP: "10", congelacionBTU: 36000 },
  { largo: 6, ancho: 9.75, alto: 3, volumen: 175.5, enfriamientoHP: "5", enfriamientoBTU: 41600, congelacionHP: "10", congelacionBTU: 40000 },
  { largo: 6, ancho: 10.97, alto: 3, volumen: 197.46, enfriamientoHP: "5", enfriamientoBTU: 52000, congelacionHP: "12", congelacionBTU: 48000 },
  { largo: 6, ancho: 12.19, alto: 3, volumen: 219.42, enfriamientoHP: "6", enfriamientoBTU: 52000, congelacionHP: "12", congelacionBTU: 48000 },
  { largo: 12.19, ancho: 7.31, alto: 3, volumen: 267.327, enfriamientoHP: "6", enfriamientoBTU: 52000, congelacionHP: "15", congelacionBTU: 56000 },
  { largo: 12.19, ancho: 8.53, alto: 3, volumen: 311.942, enfriamientoHP: "8", enfriamientoBTU: 74000, congelacionHP: "15", congelacionBTU: 62000 },
  { largo: 12.19, ancho: 9.75, alto: 3, volumen: 356.558, enfriamientoHP: "8", enfriamientoBTU: 74000, congelacionHP: "15", congelacionBTU: 62000 },
  { largo: 12.19, ancho: 10.97, alto: 3, volumen: 401.173, enfriamientoHP: "8", enfriamientoBTU: 74000, congelacionHP: "20", congelacionBTU: 78000 },
  { largo: 12.19, ancho: 12.19, alto: 3, volumen: 445.788, enfriamientoHP: "10", enfriamientoBTU: 74000, congelacionHP: "20", congelacionBTU: 78000 },
];

const state = {
  mode: "dimensions",
  selectedIndex: 0,
  selection: null,
  panelPlan: null,
};

const els = {
  form: document.querySelector("#calculator"),
  modeButtons: document.querySelectorAll(".seg"),
  usageCards: document.querySelectorAll(".usage-card"),
  dimensionsPanel: document.querySelector("#dimensions-panel"),
  volumePanel: document.querySelector("#volume-panel"),
  length: document.querySelector("#length"),
  width: document.querySelector("#width"),
  height: document.querySelector("#height"),
  directVolume: document.querySelector("#direct-volume"),
  volumeOutput: document.querySelector("#volume-output"),
  hpOutput: document.querySelector("#hp-output"),
  btuOutput: document.querySelector("#btu-output"),
  matchLabel: document.querySelector("#match-label"),
  roomOutput: document.querySelector("#room-output"),
  rangeOutput: document.querySelector("#range-output"),
  statusNote: document.querySelector("#status-note"),
  resetButton: document.querySelector("#reset-button"),
  panelTotal: document.querySelector("#panel-total"),
  wallCuts: document.querySelector("#wall-cuts"),
  wallDetail: document.querySelector("#wall-detail"),
  roofChoice: document.querySelector("#roof-choice"),
  roofDetail: document.querySelector("#roof-detail"),
  wasteTotal: document.querySelector("#waste-total"),
  panelCards: document.querySelector("#panel-cards"),
  roomPreview: document.querySelector("#room-preview"),
  includePower: document.querySelector("#include-power"),
  exportReport: document.querySelector("#export-report"),
  splash: document.querySelector("#splash"),
};

const numberFormat = new Intl.NumberFormat("es-NI", {
  maximumFractionDigits: 2,
  minimumFractionDigits: 0,
});

function toNumber(value) {
  const parsed = Number.parseFloat(value);
  return Number.isFinite(parsed) && parsed > 0 ? parsed : 0;
}

function getVolume() {
  if (state.mode === "volume") {
    return toNumber(els.directVolume.value);
  }

  return toNumber(els.length.value) * toNumber(els.width.value) * toNumber(els.height.value);
}

function getUsage() {
  return new FormData(els.form).get("usage");
}

function findSelection(volume) {
  if (!volume) return CAPACITY_TABLE[0];
  const exactOrNext = CAPACITY_TABLE.find((row) => row.volumen >= volume);
  return exactOrNext ?? CAPACITY_TABLE[CAPACITY_TABLE.length - 1];
}

function formatMeters(value) {
  return numberFormat.format(value);
}

function formatBtu(value) {
  return new Intl.NumberFormat("en-US").format(value);
}

function roundUp(value) {
  return Math.ceil(value);
}

function packCuts(cuts) {
  const panels = [];
  const sorted = [...cuts].sort((a, b) => b.length - a.length);

  sorted.forEach((cut) => {
    let best = null;
    let bestRemaining = 13;

    panels.forEach((panel) => {
      const remaining = 12 - panel.used;
      if (remaining >= cut.length && remaining < bestRemaining) {
        best = panel;
        bestRemaining = remaining;
      }
    });

    if (!best) {
      best = { cuts: [], used: 0 };
      panels.push(best);
    }

    best.cuts.push(cut);
    best.used += cut.length;
  });

  return panels.map((panel) => ({
    ...panel,
    waste: Math.max(0, 12 - panel.used),
  }));
}

function buildPlan(length, width, height, roofCutLength, roofCutCount, orientation) {
  const lengthCuts = roundUp(length);
  const widthCuts = roundUp(width);
  const wallCuts = (lengthCuts * 2) + (widthCuts * 2);
  const cuts = [
    ...Array.from({ length: wallCuts }, () => ({ length: height, kind: "Pared" })),
    ...Array.from({ length: roofCutCount }, () => ({ length: roofCutLength, kind: "Techo" })),
  ];
  const panels = packCuts(cuts);
  const totalUsed = panels.reduce((sum, panel) => sum + panel.used, 0);

  return {
    orientation,
    panels,
    wallCuts,
    lengthCuts,
    widthCuts,
    roofCutLength,
    roofCutCount,
    totalUsed,
    totalWaste: (panels.length * 12) - totalUsed,
  };
}

function betterPlan(a, b) {
  if (a.panels.length !== b.panels.length) return a.panels.length < b.panels.length ? a : b;
  if (a.totalWaste !== b.totalWaste) return a.totalWaste < b.totalWaste ? a : b;
  if (a.roofCutLength !== b.roofCutLength) return a.roofCutLength < b.roofCutLength ? a : b;
  return a;
}

function getPanelPlan() {
  if (state.mode !== "dimensions") return null;

  const length = toNumber(els.length.value);
  const width = toNumber(els.width.value);
  const height = toNumber(els.height.value);
  if (!length || !width || !height) return null;

  const widthRoof = buildPlan(length, width, height, roundUp(width), roundUp(length), "A lo ancho");
  const lengthRoof = buildPlan(length, width, height, roundUp(length), roundUp(width), "A lo largo");
  return {
    length,
    width,
    height,
    ...betterPlan(widthRoof, lengthRoof),
  };
}

function describeCuts(cuts) {
  const counts = new Map();
  cuts.forEach((cut) => {
    const key = `${formatMeters(cut.length)} m`;
    counts.set(key, (counts.get(key) || 0) + 1);
  });
  return [...counts.entries()].map(([length, count]) => `${count} x ${length}`).join(", ");
}

function renderPanelCards(plan) {
  if (!plan) {
    els.panelCards.innerHTML = `<div class="empty-state">Ingresa largo, ancho y altura para calcular paneles.</div>`;
    return;
  }

  els.panelCards.innerHTML = plan.panels.map((panel, index) => {
    const usedPercent = Math.min(100, Math.round((panel.used / 12) * 100));
    const wasteClass = panel.waste === 0 ? "good" : "neutral";
    return `
      <article class="cut-card">
        <div class="cut-card-top">
          <strong>Panel ${index + 1}</strong>
          <span>${usedPercent}% usado</span>
        </div>
        <p>${describeCuts(panel.cuts)}</p>
        <div class="usage-bar" aria-label="Uso del panel">
          <i style="width:${usedPercent}%"></i>
        </div>
        <div class="cut-meta">
          <span>Usado <b>${formatMeters(panel.used)} m</b></span>
          <span class="${wasteClass}">Sobrante <b>${formatMeters(panel.waste)} m</b></span>
        </div>
      </article>
    `;
  }).join("");
}

function renderRoomPreview(plan) {
  if (!plan) {
    els.roomPreview.innerHTML = `<span>Vista de paneles</span>`;
    return;
  }

  const roofCount = plan.orientation === "A lo ancho" ? plan.lengthCuts : plan.widthCuts;

  const lerp = (a, b, t) => ({
    x: a.x + ((b.x - a.x) * t),
    y: a.y + ((b.y - a.y) * t),
  });
  const line = (a, b, className) => `<line class="${className}" x1="${a.x}" y1="${a.y}" x2="${b.x}" y2="${b.y}" />`;
  const divisions = (count, a1, a2, b1, b2, className) => Array.from({ length: Math.max(0, count - 1) }, (_, i) => {
    const t = (i + 1) / count;
    return line(lerp(a1, a2, t), lerp(b1, b2, t), className);
  }).join("");

  const frontTopLeft = { x: 155, y: 145 };
  const frontTopRight = { x: 365, y: 145 };
  const frontBottomLeft = { x: 155, y: 305 };
  const frontBottomRight = { x: 365, y: 305 };
  const depth = { x: 88, y: -52 };
  const backTopLeft = { x: frontTopLeft.x + depth.x, y: frontTopLeft.y + depth.y };
  const backTopRight = { x: frontTopRight.x + depth.x, y: frontTopRight.y + depth.y };
  const backBottomRight = { x: frontBottomRight.x + depth.x, y: frontBottomRight.y + depth.y };

  els.roomPreview.innerHTML = `
    <div class="preview-label">L ${formatMeters(plan.length)}m  A ${formatMeters(plan.width)}m  H ${formatMeters(plan.height)}m</div>
    <svg class="room-svg" viewBox="0 0 560 380" role="img" aria-label="Cuarto frio abierto con paneles">
      <polygon class="svg-side" points="${frontTopRight.x},${frontTopRight.y} ${backTopRight.x},${backTopRight.y} ${backBottomRight.x},${backBottomRight.y} ${frontBottomRight.x},${frontBottomRight.y}" />
      <polygon class="svg-front" points="${frontTopLeft.x},${frontTopLeft.y} ${frontTopRight.x},${frontTopRight.y} ${frontBottomRight.x},${frontBottomRight.y} ${frontBottomLeft.x},${frontBottomLeft.y}" />
      <polygon class="svg-roof" points="${backTopLeft.x},${backTopLeft.y} ${backTopRight.x},${backTopRight.y} ${frontTopRight.x},${frontTopRight.y} ${frontTopLeft.x},${frontTopLeft.y}" />

      ${divisions(plan.widthCuts, frontTopRight, backTopRight, frontBottomRight, backBottomRight, "svg-panel-line")}
      ${divisions(plan.lengthCuts, frontTopLeft, frontTopRight, frontBottomLeft, frontBottomRight, "svg-panel-line")}
      ${divisions(roofCount, backTopLeft, backTopRight, frontTopLeft, frontTopRight, "svg-roof-line")}

      <polyline class="svg-edge" points="${frontTopLeft.x},${frontTopLeft.y} ${frontBottomLeft.x},${frontBottomLeft.y} ${frontBottomRight.x},${frontBottomRight.y} ${frontTopRight.x},${frontTopRight.y}" />
      <polyline class="svg-edge" points="${frontTopRight.x},${frontTopRight.y} ${backTopRight.x},${backTopRight.y} ${backBottomRight.x},${backBottomRight.y} ${frontBottomRight.x},${frontBottomRight.y}" />
      <polyline class="svg-edge-red" points="${backTopLeft.x},${backTopLeft.y} ${backTopRight.x},${backTopRight.y} ${frontTopRight.x},${frontTopRight.y} ${frontTopLeft.x},${frontTopLeft.y} ${backTopLeft.x},${backTopLeft.y}" />
    </svg>
  `;
}

function renderPanelSummary(plan) {
  if (!plan) {
    state.panelPlan = null;
    els.panelTotal.textContent = "--";
    els.wallCuts.textContent = "--";
    els.wallDetail.textContent = "Usa el modo medidas para calcular cortes.";
    els.roofChoice.textContent = "--";
    els.roofDetail.textContent = "--";
    els.wasteTotal.textContent = "--";
    renderPanelCards(null);
    renderRoomPreview(null);
    return;
  }

  state.panelPlan = plan;
  els.panelTotal.textContent = `${plan.panels.length}`;
  els.wallCuts.textContent = `${plan.wallCuts} cortes de ${formatMeters(plan.height)} m`;
  els.wallDetail.textContent = `Largo: ${plan.lengthCuts} por lado | Ancho: ${plan.widthCuts} por lado`;
  els.roofChoice.textContent = plan.orientation;
  els.roofDetail.textContent = `${plan.roofCutCount} cortes de ${formatMeters(plan.roofCutLength)} m`;
  els.wasteTotal.textContent = `${formatMeters(plan.totalWaste)} m`;
  renderPanelCards(plan);
  renderRoomPreview(plan);
}

function updateResult() {
  const volume = getVolume();
  const usage = getUsage();
  const selection = findSelection(volume);
  state.selection = selection;
  state.selectedIndex = CAPACITY_TABLE.indexOf(selection);

  const prefix = usage === "enfriamiento" ? "enfriamiento" : "congelacion";
  const hp = selection[`${prefix}HP`];
  const btu = selection[`${prefix}BTU`];
  const overMax = volume > CAPACITY_TABLE[CAPACITY_TABLE.length - 1].volumen;

  els.volumeOutput.textContent = `${numberFormat.format(volume)} m3`;
  els.hpOutput.textContent = `${hp} HP`;
  els.btuOutput.textContent = `${formatBtu(btu)} BTU`;
  els.roomOutput.textContent = `${formatMeters(selection.largo)} x ${formatMeters(selection.ancho)} x ${formatMeters(selection.alto)} m`;
  els.rangeOutput.textContent = `Cubre hasta ${formatMeters(selection.volumen)} m3`;
  els.matchLabel.textContent = overMax ? "Fuera de tabla: mayor disponible" : "Seleccion inmediata superior";
  els.statusNote.textContent = overMax
    ? "El volumen supera la tabla original. Se muestra la capacidad mayor disponible; conviene validar la carga termica con ingenieria."
    : "La seleccion se redondea hacia arriba usando el siguiente volumen disponible en la tabla original.";

  renderPanelSummary(getPanelPlan());
}

function setMode(mode) {
  state.mode = mode;
  els.modeButtons.forEach((button) => {
    button.classList.toggle("active", button.dataset.mode === mode);
  });
  els.dimensionsPanel.classList.toggle("hidden", mode !== "dimensions");
  els.volumePanel.classList.toggle("hidden", mode !== "volume");
  updateResult();
}

function resetDefaults() {
  els.length.value = "0";
  els.width.value = "0";
  els.height.value = "0";
  els.directVolume.value = "0";
  document.querySelector("input[name='usage'][value='enfriamiento']").checked = true;
  renderUsageCards();
  setMode("dimensions");
}

function renderUsageCards() {
  els.usageCards.forEach((card) => {
    card.classList.toggle("active", card.querySelector("input").checked);
  });
}

function escapeHtml(value) {
  return String(value).replace(/[&<>"']/g, (char) => ({
    "&": "&amp;",
    "<": "&lt;",
    ">": "&gt;",
    "\"": "&quot;",
    "'": "&#39;",
  })[char]);
}

function exportExcel() {
  const plan = state.panelPlan;
  if (!plan) return;

  const usage = getUsage();
  const prefix = usage === "enfriamiento" ? "enfriamiento" : "congelacion";
  const selection = state.selection;
  const includePower = els.includePower.checked;
  const rows = plan.panels.map((panel, index) => `
    <tr>
      <td>${index + 1}</td>
      <td>${escapeHtml(describeCuts(panel.cuts))}</td>
      <td>${formatMeters(panel.used)}</td>
      <td>${formatMeters(panel.waste)}</td>
    </tr>
  `).join("");

  const powerBlock = includePower ? `
    <h2>Equipo recomendado</h2>
    <table>
      <tr><th>Uso</th><th>Volumen calculado</th><th>Condensador HP</th><th>Evaporador BTU</th><th>Referencia</th></tr>
      <tr>
        <td>${usage}</td>
        <td>${formatMeters(getVolume())} m3</td>
        <td>${selection[`${prefix}HP`]} HP</td>
        <td>${formatBtu(selection[`${prefix}BTU`])} BTU</td>
        <td>${formatMeters(selection.largo)} x ${formatMeters(selection.ancho)} x ${formatMeters(selection.alto)} m</td>
      </tr>
    </table>
  ` : "";

  const html = `
    <html>
      <head>
        <meta charset="utf-8" />
        <style>
          body { font-family: Segoe UI, Arial, sans-serif; color:#17202a; }
          h1 { color:#ed1c24; }
          h2 { color:#27313a; margin-top:24px; }
          table { border-collapse: collapse; width: 100%; margin-top: 10px; }
          th { background:#ed1c24; color:#fff; }
          th, td { border:1px solid #cfd8dc; padding:8px; text-align:left; }
          .summary td:first-child { font-weight:bold; color:#7f7f7f; width:220px; }
        </style>
      </head>
      <body>
        <h1>Reporte FRIOCALC - Paneles</h1>
        <table class="summary">
          <tr><td>Largo</td><td>${formatMeters(plan.length)} m</td></tr>
          <tr><td>Ancho</td><td>${formatMeters(plan.width)} m</td></tr>
          <tr><td>Altura</td><td>${formatMeters(plan.height)} m</td></tr>
          <tr><td>Total paneles</td><td>${plan.panels.length}</td></tr>
          <tr><td>Paredes</td><td>${plan.wallCuts} cortes de ${formatMeters(plan.height)} m</td></tr>
          <tr><td>Techo recomendado</td><td>${plan.orientation}: ${plan.roofCutCount} cortes de ${formatMeters(plan.roofCutLength)} m</td></tr>
          <tr><td>Desperdicio total</td><td>${formatMeters(plan.totalWaste)} m</td></tr>
        </table>
        <h2>Desglose por panel</h2>
        <table>
          <tr><th>Panel</th><th>Cortes</th><th>Usado m</th><th>Sobrante m</th></tr>
          ${rows}
        </table>
        ${powerBlock}
      </body>
    </html>
  `;

  const blob = new Blob(["\ufeff", html], { type: "application/vnd.ms-excel;charset=utf-8" });
  const url = URL.createObjectURL(blob);
  const link = document.createElement("a");
  link.href = url;
  link.download = `reporte-friocalc-${new Date().toISOString().slice(0, 10)}.xls`;
  document.body.appendChild(link);
  link.click();
  link.remove();
  URL.revokeObjectURL(url);
}

els.modeButtons.forEach((button) => {
  button.addEventListener("click", () => setMode(button.dataset.mode));
});

els.form.addEventListener("input", updateResult);
els.form.addEventListener("change", () => {
  renderUsageCards();
  updateResult();
});
els.resetButton.addEventListener("click", resetDefaults);
els.exportReport.addEventListener("click", exportExcel);

setTimeout(() => {
  els.splash.classList.add("done");
}, 3000);

if ("serviceWorker" in navigator) {
  window.addEventListener("load", () => {
    navigator.serviceWorker.register("./sw.js").catch(() => {});
  });
}

updateResult();
